using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Configuration.Domain.Validations;

namespace Cafe.Configuration.Domain.Factories
{
    public class Factory : IFactory
    {
        public EntityBase CreateCoffeeGrower(string name, string mail, string password, string token, List<Crop> crops = null, Guid? id = null)
        {
            return new CoffeeGrower(name, mail, password, token, crops, id);
        }

        public EntityBase CreateCrop(string name, int dayFormation, string coffeeGrowerId, string configurationCropId = null)
        {
            return new Crop(name, dayFormation, coffeeGrowerId, configurationCropId);
        }

        public EntityBase CreateConfigurationCrop(string cropId, List<Climate> climates = null)
        {
            return new ConfigurationCrop(cropId, climates);
        }

        public EntityBase CreateTemperature(string ConfigurationCropId, double MinimumThresholdInsectDevelopment,
            double MaximunThresholdInsectDevelioment, double MinimumEffectiveGrade)
        {
            return new Temperature(ConfigurationCropId, MinimumThresholdInsectDevelopment,
                MaximunThresholdInsectDevelioment, MinimumEffectiveGrade);
        }
    }
}
