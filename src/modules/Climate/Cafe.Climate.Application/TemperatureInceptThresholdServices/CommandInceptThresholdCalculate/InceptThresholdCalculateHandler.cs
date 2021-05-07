using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Climate.Application.TemperatureInceptThresholdServices.CommandInceptThresholdCalculate
{
    public class InceptThresholdCalculateHandler : IRequestHandler<InceptThresholdCalculate, InceptThresholdCalculateDTO>
    {
        public Task<InceptThresholdCalculateDTO> Handle(InceptThresholdCalculate request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
