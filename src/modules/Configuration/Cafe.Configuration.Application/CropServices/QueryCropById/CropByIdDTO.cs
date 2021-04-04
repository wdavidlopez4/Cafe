using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.CropServices.QueryCropById
{
    public class CropByIdDTO
    {
        public string Name { get; set; }

        public int DayFormation { get; set; }

        public string ConfigurationCropId { get; set; }

        public string CoffeeGrowerId { get; set; }

        public CoffeeGrower CoffeeGrower { get; }

        public ConfigurationCrop ConfigurationCrop { get; }
    }
}
