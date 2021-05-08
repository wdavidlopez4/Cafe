using Cafe.Climate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Factories
{
    public interface IFactory
    {
        public EntityBase CreateArduino(Guid id, string monitoringId, bool occupied);

        public EntityBase CreateArduino(Guid id, List<ArduinoData> ArduinoDatas);

        public EntityBase CreateArduinoData(double temperature, double humididy, double altitude, DateTime time, string ArduinoId);

        public EntityBase ClimateAccumulated(double accumulatedTemperature, double accumulatedHumedity,
             double accumulatedAltitude, int contData, string monitoringId, Guid? id = null);

        public EntityBase CreateMonitoring(string cropId, List<ClimaticFactor> climate = null, Guid? id = null);

        public EntityBase CreateTemperatureInceptThreshold(string monitoringId, OptimalDevelopmentThresholdEnum optimalStateDevelopmentThreshold,
            double optimalTemperatureDevelopmentThreshold, Guid? id = null);

        public EntityBase CreateCrop(Guid id, string name, string coffeeGrowerId);

        public EntityBase CreateTemperatureDegreesDays(string monitoringId, double degreesDays, DateTime time);

    }
}
