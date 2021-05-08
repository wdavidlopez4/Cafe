using Cafe.Climate.Application.Exceptions;
using Cafe.Climate.Domain.Entities;
using Cafe.Climate.Domain.Factories;
using Cafe.Climate.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Climate.Application.TemperatureDegreesDaysServices.CommandDegreesDaysCalculate
{
    public class DegreesDaysCalculateHandler : IRequestHandler<DegreesDaysCalculate, DegreesDaysCalculateDTO>
    {
        private readonly IRepository repository;

        private readonly IFactory factory;

        private readonly IAutoMapping autoMapping;

        public DegreesDaysCalculateHandler(IRepository repository, IFactory factory, IAutoMapping autoMapping)
        {
            this.autoMapping = autoMapping;
            this.factory = factory;
            this.repository = repository;
        }

        public async Task<DegreesDaysCalculateDTO> Handle(DegreesDaysCalculate request, CancellationToken cancellationToken)
        {
            TemperatureDegreesDays temperatureDegreesDays;
            ClimateAccumulated climateAccumulated;
            Monitoring monitoring;
            double degreesDays;

            //verificamos peticion
            if (request == null)
                throw new EntityNullException("la peticion para consultat el humbral optimo de desarrollo es nula");

            //obtener el id del caficultor del token que me enviaron y verificamos si existe
            var coffeeGowerId = request.Claims.Find(x => x.Type == "CoffeeGrowerId").Value;
            if (coffeeGowerId == null)
                throw new TokenException("no se pudo recuperar el id del claim");

            else if (this.repository.Exists<Crop>(x => x.Id == request.CropId && x.CoffeeGrowerId == coffeeGowerId) == false)
                throw new EntityNullException("el id del caficultor no correspondel al cultivo o el cultivo no existe");

            //obtenemos el cultivo, el acumulado y el monitoreo (verificamos)
            var crop = await this.repository.GetWithNestedObject<Crop>(
                x => x.Id == request.CropId,
                x => x.Monitoring.ClimateAccumulated,
                cancellationToken);

            climateAccumulated = crop.Monitoring.ClimateAccumulated;
            monitoring = crop.Monitoring;

            if (climateAccumulated == null)
                throw new EntityNullException("el acumulador de clima no se pudo recuperar. lo mas provable es que el arduino no a logrado comunicar");

            //hay que generar un evento para recuperar la configuracion: mini.humb.de.desarro = 16
            degreesDays = (climateAccumulated.AccumulatedTemperature / climateAccumulated.ContData) - 16;

            //crea, guarda, mapea y retorna la temperatura de grados dia
            temperatureDegreesDays = (TemperatureDegreesDays)this.factory.CreateTemperatureDegreesDays(monitoring.Id, degreesDays, DateTime.UtcNow);
            temperatureDegreesDays = await this.repository.Save<TemperatureDegreesDays>(temperatureDegreesDays, cancellationToken);
            return this.autoMapping.Map<TemperatureDegreesDays, DegreesDaysCalculateDTO>(temperatureDegreesDays);
        }
    }
}
