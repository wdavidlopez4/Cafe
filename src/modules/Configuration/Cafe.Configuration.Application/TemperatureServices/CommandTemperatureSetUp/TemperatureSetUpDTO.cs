using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.TemperatureServices.CommandTemperatureSetUp
{
    public class TemperatureSetUpDTO
    {
        public double MinimumThresholdInsectDevelopment { get; private set; }

        public double MaximunThresholdInsectDevelioment { get; private set; }

        public double MinimumEffectiveGrade { get; private set; }

        public string ConfigurationCropId { get; private set; }

        public ConfigurationCrop ConfigurationCrop { get; private set; }
    }
}
