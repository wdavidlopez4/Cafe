using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Cafe.Configuration.Application.TemperatureServices.CommandTemperatureSetUp
{
    public class TemperatureSetUp : IRequest<TemperatureSetUpDTO>
    {
        public double MinimumThresholdInsectDevelopment { get; set; }

        public double MaximunThresholdInsectDevelioment { get; set; }

        public double MinimumEffectiveGrade { get; set; }

        public List<Claim> Claims { get; set; }

        public string CropId { get; set; }
    }
}
