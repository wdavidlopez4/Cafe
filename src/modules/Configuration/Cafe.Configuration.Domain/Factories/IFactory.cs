﻿using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Factories
{
    public interface IFactory
    {
        public EntityBase CreateCoffeeGrower(string name, string mail, string password, string token, List<Crop> crops = null, Guid? id = null);

        public EntityBase CreateCrop(string name, int dayFormation, string coffeeGrowerId);

        public EntityBase CreateConfigurationCrop(string cropId, Temperature temperature = null, Arduino arduino = null);

        public EntityBase CreateTemperature(string ConfigurationCropId, double MinimumThresholdInsectDevelopment,
            double MaximunThresholdInsectDevelioment, double MinimumEffectiveGrade, ConfigurationCrop configurationCrop = null);

        public EntityBase CreateArduino(string name, string configurationCropId, ConfigurationCrop configurationCrop = null, 
            Guid? id = null, bool occupied = false);
    }
}
