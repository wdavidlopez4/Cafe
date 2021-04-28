using Cafe.Configuration.IntegrationEvents.CropEvents;
using JKang.EventBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Climate.Application.CropEventHandler
{
    public class CropCreateEventHandler : IEventHandler<CropCreateEvent>
    {
        public Task HandleEventAsync(CropCreateEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
