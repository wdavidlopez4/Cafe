using Cafe.Configuration.IntegrationEvents.MonitoringEvents;
using Cafe.Intelligent.Application.ML;
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
        private readonly MLFit mLFit;

        public MonitoringImageEventHandler(MLFit mLFit)
        {
            this.mLFit = mLFit;
        }

        public async Task HandleEventAsync(MonitoringImageBeginEvent @event)
        {
            //preparar los dataSet para la IA
            var preProcessedData = await this.mLFit.PrepareData();

            //dividir los dataser en datos de validacion, prueba y entrenamiento
            (IDataView trainSet, IDataView validationSet, IDataView testSet) = this.mLFit.DivideData(preProcessedData);

            //entrenar la IA
            this.mLFit.Fit(trainSet, validationSet, testSet);

        }
    }
}
