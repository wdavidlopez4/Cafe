using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.CropServices.CommandCropCreate
{
    public class CropCreate : IRequest<CropCreateDTO>
    {
        public string Nombre { get; set; }

        public int DiasFormacion { get; set; }

        public string CoffeeGrowerId { get; set; }
    }
}
