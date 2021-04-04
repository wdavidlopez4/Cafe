using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Cafe.Configuration.Application.CropServices.CommandCropCreate
{
    public class CropCreate : IRequest<CropCreateDTO>
    {
        public string Name { get; set; }

        public int DayFormation { get; set; }

        public string CoffeeGrowerId { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
