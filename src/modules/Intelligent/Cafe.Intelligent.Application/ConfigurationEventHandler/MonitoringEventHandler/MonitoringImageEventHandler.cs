using Cafe.Configuration.IntegrationEvents.MonitoringEvents;
using JKang.EventBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Intelligent.Application.ConfigurationEventHandler.MonitoringEventHandler
{
    public class MonitoringImageEventHandler : IEventHandler<MonitoringImageBeginEvent>
    {
        public Task HandleEventAsync(MonitoringImageBeginEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
