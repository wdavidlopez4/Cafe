using Cafe.Configuration.IntegrationEvents.MonitoringEvents;
using Cafe.Intelligent.Application.ML;
using Cafe.Intelligent.Domain.Ports;
using JKang.EventBus;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Intelligent.Application.ConfigurationEventHandler.MonitoringEventHandler
{
    public class MonitoringImageEventHandler : IEventHandler<MonitoringImageBeginEvent>
    {

        private readonly IAutoMapping autoMapping;

        private readonly IDirectoryProgram directoryProgram;

        private readonly IRepositoryBlob repositoryBlob;

        public MonitoringImageEventHandler(IAutoMapping autoMapping, IDirectoryProgram directoryProgram,
            IRepositoryBlob repositoryBlob)
        {
            this.directoryProgram = directoryProgram;
            this.autoMapping = autoMapping;
            this.repositoryBlob = repositoryBlob;
        }

        public Task HandleEventAsync(MonitoringImageBeginEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
