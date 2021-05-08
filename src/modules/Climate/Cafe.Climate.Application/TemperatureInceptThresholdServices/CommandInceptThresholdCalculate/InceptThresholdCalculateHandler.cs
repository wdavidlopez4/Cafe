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

namespace Cafe.Climate.Application.TemperatureInceptThresholdServices.CommandInceptThresholdCalculate
{
    public class InceptThresholdCalculateHandler : IRequestHandler<InceptThresholdCalculate, InceptThresholdCalculateDTO>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        private readonly IFactory factory;

        public InceptThresholdCalculateHandler(IRepository repository, IAutoMapping autoMapping, IFactory factory)
        {
            this.autoMapping = autoMapping;
            this.repository = repository;
            this.factory = factory;
        }

        public async Task<InceptThresholdCalculateDTO> Handle(InceptThresholdCalculate request, CancellationToken cancellationToken)
        {
            OptimalDevelopmentThresholdEnum optimalDevelopmentThresholdEnum;
            double optimalTemperatureDevelopmentThreshold;
            ClimateAccumulated climateAccumulated;
            Monitoring monitoring;

            //verificamos peticion
            if (request == null)
                throw new EntityNullException("la peticion para consultat el humbral optimo de desarrollo es nula");

            //obtener el id del caficultor del token que me enviaron y verificamos si existe
            var coffeeGowerId = request.Claims.Find(x => x.Type == "CoffeeGrowerId").Value;
            if (coffeeGowerId == null)
                throw new TokenException("no se pudo recuperar el id del claim");

            else if(this.repository.Exists<Crop>(x => x.Id == request.CropId && x.CoffeeGrowerId == coffeeGowerId) == false)
                throw new EntityNullException("el id del caficultor no correspondel al cultivo o el cultivo no existe");

            //obtenemos el cultivo, el acumulado y el monitoreo (verificamos)
            var crop = await this.repository.GetWithNestedObject<Crop>(
                x => x.Id == request.CropId,
                x => x.Monitoring.ClimateAccumulated,
                cancellationToken);

            climateAccumulated = crop.Monitoring.ClimateAccumulated;
            monitoring = crop.Monitoring;

            if (climateAccumulated == null)
                throw new EntityNullException("el acumulador de clima no se pudo recuperar.");

            //calculamos el optimo umbral de desarrollo y el estado "falta generar un evento de las configuraciones para obtener los rangos"
            optimalTemperatureDevelopmentThreshold = climateAccumulated.AccumulatedTemperature / climateAccumulated.ContData;

            if (optimalTemperatureDevelopmentThreshold > 32 || optimalTemperatureDevelopmentThreshold < 15)
                optimalDevelopmentThresholdEnum = OptimalDevelopmentThresholdEnum.Low;
            else if (optimalTemperatureDevelopmentThreshold < 32 && optimalTemperatureDevelopmentThreshold > 15 && optimalTemperatureDevelopmentThreshold != 27)
                optimalDevelopmentThresholdEnum = OptimalDevelopmentThresholdEnum.Medium;
            else
                optimalDevelopmentThresholdEnum = OptimalDevelopmentThresholdEnum.High;

            //creamos, guardamos, mapeamos y retornamos la temperatura del umbral del incepto
            var temperatureInceptThreshold = (TemperatureInceptThreshold) factory.CreateTemperatureInceptThreshold(
                monitoringId: monitoring.Id,
                optimalStateDevelopmentThreshold: optimalDevelopmentThresholdEnum,
                optimalTemperatureDevelopmentThreshold: optimalTemperatureDevelopmentThreshold);

            temperatureInceptThreshold = await this.repository.Save<TemperatureInceptThreshold>(temperatureInceptThreshold, cancellationToken);

            return this.autoMapping.Map<TemperatureInceptThreshold, InceptThresholdCalculateDTO>(temperatureInceptThreshold);
        }
    }
}
