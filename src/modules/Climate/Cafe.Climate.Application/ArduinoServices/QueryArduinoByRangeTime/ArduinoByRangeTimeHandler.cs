using Cafe.Climate.Domain.Factories;
using Cafe.Climate.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Climate.Application.ArduinoServices.QueryArduinoByRangeTime
{
    public class ArduinoByRangeTimeHandler : IRequestHandler<ArduinoByRangeTime, List<ArduinoByRangeTimeDTO>>
    {
        private readonly IRepository repository;

        private readonly IFactory factory;

        private readonly IAutoMapping autoMapping;

        public ArduinoByRangeTimeHandler(IRepository repository, IFactory factory, IAutoMapping autoMapping)
        {
            this.autoMapping = autoMapping;
            this.factory = factory;
            this.repository = repository;
        }

        public Task<List<ArduinoByRangeTimeDTO>> Handle(ArduinoByRangeTime request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
