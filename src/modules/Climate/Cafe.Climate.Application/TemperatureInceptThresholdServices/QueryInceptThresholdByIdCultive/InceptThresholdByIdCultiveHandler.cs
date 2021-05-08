using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Climate.Application.TemperatureInceptThresholdServices.QueryInceptThresholdByIdCultive
{
    public class InceptThresholdByIdCultiveHandler : IRequestHandler<InceptThresholdByIdCultive, InceptThresholdByIdCultiveDTO>
    {
        public Task<InceptThresholdByIdCultiveDTO> Handle(InceptThresholdByIdCultive request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
