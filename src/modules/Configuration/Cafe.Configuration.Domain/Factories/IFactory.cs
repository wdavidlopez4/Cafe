using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Factories
{
    public interface IFactory
    {
        public EntityBase CreateCoffeeGrower(string name, string mail, string password, string token, List<Crop> crops = null, Guid? id = null);

        public EntityBase CreateCrop(string name, int DayFormation, string coffeeGrowerId,
            CoffeeGrower coffeeGrower = null, ConfigurationCrop configurationCrop = null,
            Monitoring monitoring = null);

        public EntityBase CreateConfigurationCrop(string cropId, Temperature temperature = null, Arduino arduino = null);

        public EntityBase CreateTemperature(string ConfigurationCropId, double MinimumThresholdInsectDevelopment,
            double MaximunThresholdInsectDevelioment, double MinimumEffectiveGrade, ConfigurationCrop configurationCrop = null);

        public EntityBase CreateArduino(string name, string configurationCropId, ConfigurationCrop configurationCrop = null, 
            Guid? id = null, bool occupied = false);

        public EntityBase CreateMonitoring(string activateByImage, string cropId, Crop crop = null);

        public EntityBase CreateMonitoring(bool activateManually, string cropId, Crop crop = null);
    }
}
