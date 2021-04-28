using Cafe.Climate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Factories
{
    public class Factory : IFactory
    {
        public EntityBase CreateArduino(double temperature, double humididy, double altitude, bool occupied, Monitoring monitoring = null)
        {
            return new Arduino(temperature, humididy, altitude, occupied, monitoring);
        }

        public EntityBase CreateAverageWeather(double accumulatedTemperatureWeek, double accumulatedTemperatureMonth, double accumulatedTemperatureHour, double accumulatedTemperatureMinute)
        {
            return new AverageWeather(accumulatedTemperatureWeek, accumulatedTemperatureMonth, 
                accumulatedTemperatureHour, accumulatedTemperatureMinute);
        }

        public EntityBase CreateMonitoring(string arduinoId, string cropId, List<ClimaticFactor> climate, Guid? id = null)
        {
            return new Monitoring(arduinoId, cropId, climate, id);
        }

        public EntityBase CreateTemperatureInceptThreshold(string monitoringId, string averageWeatherId, 
            string optimalStateDevelopmentThreshold, double optimalTemperatureDevelopmentThreshold, 
            double UmD, double UMD, Guid? id = null)
        {
            return new TemperatureInceptThreshold(monitoringId, averageWeatherId, optimalStateDevelopmentThreshold,
                optimalTemperatureDevelopmentThreshold, UmD, UMD, id);
        }
    }
}
