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

namespace Cafe.Climate.Application.ArduinoServices.CommandArduinoSetData
{
    public class ArduinoDataSetHandler : IRequestHandler<ArduinoDataSet, ArduinoDataSetDTO>
    {
        private readonly IRepository repository;

        private readonly IFactory factory;

        private readonly IAutoMapping autoMapping;

        public ArduinoDataSetHandler(IRepository repository, IFactory factory, IAutoMapping autoMapping)
        {
            this.factory = factory;
            this.repository = repository;
            this.autoMapping = autoMapping;
        }

        public async Task<ArduinoDataSetDTO> Handle(ArduinoDataSet request, CancellationToken cancellationToken)
        {
            //verificar request
            if (request == null)
                throw new ArgumentNullException("peticion nula para el seteo de el arduino");

            //recuperar cultivo con el arduino y verificar
            else if (this.repository.Exists<Crop>(x => x.Id == request.CropId) == false)
                throw new EntityNullException("trata de recuperar datos de un cultivo que no a creado...");

            var crop = await this.repository.GetWithNestedObject<Crop>(x => x.Id == request.CropId,
                 x => x.Monitoring.Arduino, cancellationToken);

            if (crop.Monitoring.Arduino == null)
                throw new ArgumentNullException("el arduino no se a creado");

            else if (crop.Monitoring.Arduino.Occupied == false)
                throw new ArgumentNullException("el arduino no se a sincronizado");

            else if (crop.CoffeeGrowerId != request.Claims.Find(x => x.Type == "CoffeeGrowerId").Value)
                throw new ArgumentNullException("el usuario no pertenece al cultivo. verificar el token");

            //crear, guardar y mapear los datos del arduino "temperatura humedad altitud..."
            var data = (ArduinoData) factory.CreateArduinoData(request.Temperature, request.Humididy, request.Altitude, DateTime.Now, 
                crop.Monitoring.Arduino.Id);

            //accumular datos de clima
            await AccumulateClimate(request.Temperature, request.Humididy, request.Altitude, 
                crop.Monitoring.Id, cancellationToken);


            data = await this.repository.Save<ArduinoData>(data, cancellationToken);
            return this.autoMapping.Map<ArduinoData, ArduinoDataSetDTO>(data);
        }

        /// <summary>
        /// acumula el clima
        /// </summary>
        /// <param name="IdClimateAccumulated"></param>
        /// <param name="temperature"></param>
        /// <param name="humedity"></param>
        /// <param name="altitude"></param>
        /// <param name="monitoringId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task AccumulateClimate(double temperature, double humedity, double altitude, 
            string monitoringId, CancellationToken cancellationToken)
        {
            ClimateAccumulated climateAccumulated;

            //preguntamos si hay algun acumulador que exista con el id de ese monitoreo
            if (this.repository.Exists<ClimateAccumulated>(x => x.MonitoringId == monitoringId) == false)
            {
                //crear acumulador de temperatura
                climateAccumulated = (ClimateAccumulated)this.factory.ClimateAccumulated(
                    accumulatedTemperature: temperature,
                    accumulatedHumedity: humedity,
                    accumulatedAltitude: altitude,
                    contData: 1,
                    monitoringId: monitoringId);

                //guardamos
                await this.repository.Save<ClimateAccumulated>(climateAccumulated, cancellationToken);
            }
            else
            {
                var climateAccumulared = await this.repository.Get<ClimateAccumulated>(
                    x => x.MonitoringId == monitoringId, cancellationToken);

                //crear acumulador de temperatura con los datos anteriormente guardamos
                climateAccumulated = (ClimateAccumulated)this.factory.ClimateAccumulated(
                    accumulatedTemperature: climateAccumulared.AccumulatedTemperature + temperature,
                    accumulatedHumedity: climateAccumulared.AccumulatedHumedity + humedity,
                    accumulatedAltitude: climateAccumulared.AccumulatedAltitude + altitude,
                    contData: climateAccumulared.ContData + 1,
                    monitoringId: monitoringId,
                    id: Guid.Parse(climateAccumulared.Id));

                //modificar
                await this.repository.Update<ClimateAccumulated>(climateAccumulared, cancellationToken);
            }
        }

    }
}
