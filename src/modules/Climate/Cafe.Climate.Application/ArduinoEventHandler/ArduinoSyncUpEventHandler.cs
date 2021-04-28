using Cafe.Configuration.IntegrationEvents.ArduinoEvents;
using JKang.EventBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Climate.Application.ArduinoEventHandler
{
    public class ArduinoSyncUpEventHandler : IEventHandler<ArduinoSyncUpEvent>
    {
        public Task HandleEventAsync(ArduinoSyncUpEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
