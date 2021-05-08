using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Cafe.Climate.Application.TemperatureDegreesDaysServices.CommandDegreesDaysCalculate
{
    public class DegreesDaysCalculate : IRequest<DegreesDaysCalculateDTO>
    {
        public string CropId { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
