using Cafe.Configuration.Domain.Entities;
using Cafe.Configuration.Domain.Factories;
using Cafe.Configuration.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Configuration.Application.TemperatureServices.CommandTemperatureSetUp
{
    public class TemperatureSetUpHandler : IRequestHandler<TemperatureSetUp, TemperatureSetUpDTO>
    {
        public IRepository repository;

        public IFactory factory;

        public IAutoMapping autoMapping;

        public TemperatureSetUpHandler(IRepository repository, IFactory factory, IAutoMapping autoMapping)
        {
            this.factory = factory;
            this.autoMapping = autoMapping;
            this.repository = repository;
        }

        public async Task<TemperatureSetUpDTO> Handle(TemperatureSetUp request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentException("la peticion para configurar la temperatura del sistema nunca se recibio.");

            //recuperar el id del caficultor y ver si existe
            var coffeeGrowerId = request.Claims.Find(x => x.Type == "CoffeeGrowerId").Value;

            if (this.repository.Exists<CoffeeGrower>(x => x.Id == coffeeGrowerId) == false)
                throw new Exception("de acuerdo al token suministrado el caficultor no existe.");


            //obtenermos el cultivo y verificamos
            var crop = await this.repository.GetWithNestedObject<Crop>(x => x.Id == request.CropId, x => x.ConfigurationCrop.Temperature, cancellationToken);
            var configurationCrop = crop.ConfigurationCrop;

            if (crop == null)
            {
                throw new Exception("segun el id del cultivo suministrado NO EXISTE el cultivo");
            }
            else if (crop.CoffeeGrowerId != coffeeGrowerId)
            {
                throw new Exception("el cultipo del caficultor no corresponde al token del caficultor.");
            }
            else if(configurationCrop == null)
            {
                configurationCrop = (ConfigurationCrop) this.factory.CreateConfigurationCrop(crop.Id);
            }
            else if(this.repository.Exists<Temperature>(x => x.Id == configurationCrop.Temperature.Id) == true)
            {
                throw new Exception("el cultivo ya tiene una configuracion de temperatura creada.");
            }

            //creamos, guardamos, mapeamos y retornamos la temperatura configuracion
            var temperature = (Temperature) this.factory.CreateTemperature(configurationCrop.Id, request.MinimumThresholdInsectDevelopment, 
                request.MaximunThresholdInsectDevelioment, request.MinimumEffectiveGrade, configurationCrop);

            return this.autoMapping.Map<Temperature, TemperatureSetUpDTO>(await this.repository.Save<Temperature>(temperature, cancellationToken));
        }
    }
}
