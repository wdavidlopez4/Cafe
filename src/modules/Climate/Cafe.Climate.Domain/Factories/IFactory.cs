using Cafe.Climate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Factories
{
    public interface IFactory
    {
        public EntityBase CreateArduino(double temperature, double humididy, 
            double altitude, Monitoring monitoring = null);

        public EntityBase CreateAverageWeather(double accumulatedTemperatureWeek, double accumulatedTemperatureMonth,
            double accumulatedTemperatureHour, double accumulatedTemperatureMinute);

        public EntityBase CreateMonitoring(string arduinoId, List<ClimaticFactor> climate, Guid? id = null);

        public EntityBase CreateTemperatureInceptThreshold(string monitoringId, string averageWeatherId, string optimalStateDevelopmentThreshold,
            double optimalTemperatureDevelopmentThreshold, double UmD, double UMD, Guid? id);

    }
}
