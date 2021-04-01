using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.CropServices.CommandCropCreate
{
    public class CropCreateDTO
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        public int DiasFormacion { get; set; }

        public string CoffeeGrowerId { get; set; }
    }
}
