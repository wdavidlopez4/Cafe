using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.SetUpServices.QuerySetUpByIdCrop
{
    public class SetUpByIdCropDTO
    {
        public string Id { get; set; }

        public string CropId { get; set; }

        public CropDTO Crop { get; set; }

        public TemperatureDTO Temperature { get; set; }

        public ArduinoDTO Arduino { get; set; }

        public class CropDTO
        {
            public string Id { get; set; }

            public string Name { get; set; }

            public int DayFormation { get; set; }

            public string CoffeeGrowerId { get; set; }
        }

        public class TemperatureDTO
        {
            public string Id { get; set; }

            public double MinimumThresholdInsectDevelopment { get; set; }

            public double MaximunThresholdInsectDevelioment { get; set; }

            public double MinimumEffectiveGrade { get; set; }

            public string ConfigurationCropId { get; set; }
        }

        public class ArduinoDTO
        {
            public string Id { get; set; }

            public string Name { get; set; }

            public bool Occupied { get; set; }

            public string ConfigurationCropId { get; set; }
        }
    }
}
