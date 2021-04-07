﻿using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.TemperatureServices.CommandTemperatureSetUp
{
    public class TemperatureSetUpDTO
    {
        public double MinimumThresholdInsectDevelopment { get; set; }

        public double MaximunThresholdInsectDevelioment { get; set; }

        public double MinimumEffectiveGrade { get; set; }

        public string ConfigurationCropId { get; set; }

        public ConfigurationCrop ConfigurationCrop { get; }
    }
}
