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

        public async Task HandleEventAsync(MonitoringImageBeginEvent @event)
        {
            //preparar los dataSet para la IA
            var preProcessedData = await MLFit.PrepareData(directoryProgram, repositoryBlob);

            //dividir los dataser en datos de validacion, prueba y entrenamiento
            (IDataView trainSet, IDataView validationSet, IDataView testSet) = MLFit.DivideData(preProcessedData);

            //entrenar la IA
            MLFit.Fit(trainSet, validationSet, testSet);

        }
    }
}
