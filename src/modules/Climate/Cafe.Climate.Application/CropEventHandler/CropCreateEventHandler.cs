using Cafe.Climate.Application.Exceptions;
using Cafe.Climate.Domain.Entities;
using Cafe.Climate.Domain.Factories;
using Cafe.Climate.Domain.Ports;
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
        private readonly IRepository repository;

        private readonly IFactory factory;

        public CropCreateEventHandler(IRepository repository, IFactory factory)
        {
            this.factory = factory;
            this.repository = repository;
        }

        public async Task HandleEventAsync(CropCreateEvent @event)
        {
            if (this.repository.Exists<Crop>(x => x.Id == @event.Id) == true)
                throw new DuplicityEntityException("ya existe el cultivo para comenzarlo a monitorear.");

            //crear y guardar el cultivo
            var crop = (Crop)this.factory.CreateCrop(Guid.Parse(@event.Id), @event.Name);
            crop = await this.repository.Save<Crop>(crop);

            //crear y guardar el monitoreo del cultivo
            var monitoring = (Monitoring)this.factory.CreateMonitoring(crop.Id);
            monitoring = await this.repository.Save<Monitoring>(monitoring);
        }
    }
}
