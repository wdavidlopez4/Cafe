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

        public IUserSecurity userSecurity;

        public TemperatureSetUpHandler(IRepository repository, IFactory factory, IAutoMapping autoMapping, IUserSecurity userSecurity)
        {
            this.userSecurity = userSecurity;
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
            string configurationCropId = null;
            var crop = await this.repository.GetWithNestedObject<Crop>(x => x.Id == request.CropId, x => x.ConfigurationCrop, cancellationToken);

            if(crop == null)
            {
                throw new Exception("segun el id del cultivo suministrado NO EXISTE el cultivo");
            }
            else if (crop.CoffeeGrowerId != coffeeGrowerId)
            {
                throw new Exception("el cultipo del caficultor no corresponde al token del caficultor.");
            }
            else if(crop.ConfigurationCrop == null)
            {
                configurationCropId = this.factory.CreateConfigurationCrop(crop.Id).Id;
            }
            else if(crop.Id != null)
            {
                configurationCropId = crop.ConfigurationCropId;
            }

            //creamos, guardamos, mapeamos y retornamos la temperatura configuracion
            var temperature = (Temperature) this.factory.CreateTemperature(configurationCropId, 
                request.MaximunThresholdInsectDevelioment, request.MaximunThresholdInsectDevelioment, request.MinimumEffectiveGrade);

            return this.autoMapping.Map<Temperature, TemperatureSetUpDTO>(await this.repository.Save<Temperature>(temperature, cancellationToken));
        }
    }
}
