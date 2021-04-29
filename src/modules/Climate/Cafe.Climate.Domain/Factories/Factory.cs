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

        public EntityBase CreateAverageWeather(double accumulatedTemperatureWeek, double accumulatedTemperatureMonth, double accumulatedTemperatureHour, double accumulatedTemperatureMinute)
        {
            return new AverageWeather(accumulatedTemperatureWeek, accumulatedTemperatureMonth, 
                accumulatedTemperatureHour, accumulatedTemperatureMinute);
        }

        public EntityBase CreateMonitoring(string cropId, List<ClimaticFactor> climate = null, Guid? id = null)
        {
            return new Monitoring(cropId, climate, id);
        }

        public EntityBase CreateTemperatureInceptThreshold(string monitoringId, string averageWeatherId, 
            string optimalStateDevelopmentThreshold, double optimalTemperatureDevelopmentThreshold, 
            double UmD, double UMD, Guid? id = null)
        {
            return new TemperatureInceptThreshold(monitoringId, averageWeatherId, optimalStateDevelopmentThreshold,
                optimalTemperatureDevelopmentThreshold, UmD, UMD, id);
        }

        public EntityBase CreateCrop(Guid id, string name)
        {
            return new Crop(id, name);
        }
    }
}
