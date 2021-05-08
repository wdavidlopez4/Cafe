using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Cafe.Climate.Application.TemperatureInceptThresholdServices.CommandInceptThresholdCalculate
{
    public class InceptThresholdCalculate : IRequest<InceptThresholdCalculateDTO>
    {
        public string CropId { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
