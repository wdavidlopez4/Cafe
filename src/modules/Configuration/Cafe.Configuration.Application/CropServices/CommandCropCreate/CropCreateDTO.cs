using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.CropServices.CommandCropCreate
{
    public class CropCreateDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int DayFormation { get; set; }

        public string CoffeeGrowerId { get; set; }
    }
}
