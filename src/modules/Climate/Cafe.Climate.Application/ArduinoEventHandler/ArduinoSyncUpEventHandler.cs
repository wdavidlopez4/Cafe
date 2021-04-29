using Cafe.Climate.Application.Exceptions;
using Cafe.Climate.Domain.Entities;
using Cafe.Climate.Domain.Factories;
using Cafe.Climate.Domain.Ports;
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
        private readonly IRepository repository;

        private readonly IFactory factory;

        public ArduinoSyncUpEventHandler(IRepository repository, IFactory factory)
        {
            this.factory = factory;
            this.repository = repository;
        }

        public async Task HandleEventAsync(ArduinoSyncUpEvent @event)
        {
            if (this.repository.Exists<Crop>(x => x.Id == @event.CropId) == false)
                throw new EntityNullException("la operacion es invalida por que aun no se a ejecutado el evento para el cultivo");

            //obtenemos el cultivo con el monitoreo
            var crop = await this.repository.GetWithNestedObject<Crop>(x => x.Id == @event.CropId, x => x.Monitoring);

            //creamos y guardamos el arduino "sincronizamos el arduino (true)"
            var arduino = (Arduino) this.factory.CreateArduino(Guid.Parse(@event.Id), crop.Monitoring.Id, true);
            arduino = await this.repository.Save<Arduino>(arduino);
        }
    }
}
