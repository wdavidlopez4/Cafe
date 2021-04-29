using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Climate.Application.ArduinoServices.CommandArduinoSetData
{
    public class ArduinoSetDataHandler : IRequestHandler<ArduinoSetData, ArduinoSetDataDTO>
    {
        public Task<ArduinoSetDataDTO> Handle(ArduinoSetData request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
