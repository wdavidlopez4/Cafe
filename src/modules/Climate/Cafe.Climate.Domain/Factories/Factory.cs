using Cafe.Climate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Factories
{
    public class Factory : IFactory
    {
        public EntityBase CreateArduino(Guid id, string monitoringId, bool occupied)
        {
            return new Arduino(id, monitoringId, occupied);
        }

        public EntityBase CreateArduino(Guid id, List<ArduinoData> ArduinoDatas)
        {
            return new Arduino(id, ArduinoDatas);
        }

        public EntityBase CreateArduinoData(double temperature, double humididy, double altitude, DateTime time, string ArduinoId)
        {
            return new ArduinoData(temperature, humididy, altitude, time, ArduinoId);
        }

        public EntityBase ClimateAccumulated(double accumulatedTemperature, double accumulatedHumedity,
            double accumulatedAltitude, int contData, string monitoringId, Guid? id = null)
        {
            return new ClimateAccumulated(accumulatedTemperature, accumulatedHumedity, 
                accumulatedAltitude, contData, monitoringId, id);
        }

        public EntityBase CreateMonitoring(string cropId, List<ClimaticFactor> climate = null, Guid? id = null)
        {
            return new Monitoring(cropId, climate, id);
        }

        public EntityBase CreateTemperatureInceptThreshold(string monitoringId, OptimalDevelopmentThresholdEnum optimalStateDevelopmentThreshold,
            double optimalTemperatureDevelopmentThreshold, Guid? id = null)
        {
            return new TemperatureInceptThreshold(monitoringId, optimalStateDevelopmentThreshold, 
                optimalTemperatureDevelopmentThreshold, id);
        }

        public EntityBase CreateCrop(Guid id, string name, string coffeeGrowerId)
        {
            return new Crop(id, name, coffeeGrowerId);
        }

        public EntityBase CreateTemperatureDegreesDays(string monitoringId, double degreesDays, DateTime time)
        {
            return new TemperatureDegreesDays(monitoringId, degreesDays, time);
        }
    }
}
