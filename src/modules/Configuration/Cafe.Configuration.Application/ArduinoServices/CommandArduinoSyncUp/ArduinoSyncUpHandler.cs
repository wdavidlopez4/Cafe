using Cafe.Configuration.Application.Exceptions;
using Cafe.Configuration.Domain.Entities;
using Cafe.Configuration.Domain.Factories;
using Cafe.Configuration.Domain.Ports;
using Cafe.Configuration.IntegrationEvents.ArduinoEvents;
using JKang.EventBus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Configuration.Application.ArduinoServices.CommandArduinoSyncUp
{
    public class ArduinoSyncUpHandler : IRequestHandler<ArduinoSyncUp, ArduinoSyncUpDTO>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        private readonly IFactory factory;

        private readonly IEventPublisher eventPublisher;


        public ArduinoSyncUpHandler(IRepository repository, IAutoMapping autoMapping, IFactory factory, 
            IEventPublisher eventPublisher)
        {
            this.factory = factory;
            this.autoMapping = autoMapping;
            this.repository = repository;
            this.eventPublisher = eventPublisher;
        }

        public async Task<ArduinoSyncUpDTO> Handle(ArduinoSyncUp request, CancellationToken cancellationToken)
        {
            //verificamos la peticion
            if (request == null)
                throw new ArgumentNullException("la peticion para sincronizar el arduino es nula.");

            //verificamos el caficultor: el clain y si existe tanto el como el arduino
            var coffeeGrowerId = request.Claims.Find(x => x.Type == "CoffeeGrowerId").Value;
            if (coffeeGrowerId == null)
                throw new TokenException("no se pudo recuperar el id del caficultor con el token enviado");

            else if (this.repository.Exists<CoffeeGrower>(x => x.Id == coffeeGrowerId) == false)
                throw new EntityNullException("el caficultor no existe de acurdo con el token enviado");

            else if(this.repository.Exists<Arduino>(x => x.Id == request.Id) == false)
                throw new EntityNullException("el arduino aun no se a creado desde la UI o no pertenece al caficultor");

            //recuperamo el arduino
            var arduino = await this.repository.GetWithNestedObject<Arduino>(x => x.Id == request.Id,
                x => x.ConfigurationCrop.Crop.CoffeeGrower, cancellationToken);

            if(arduino == null)
                throw new EntityNullException("no se pudo recuperar el arduino con el id porporcionado");
            else if(arduino.ConfigurationCrop == null)
                throw new EntityNullException("extraño: el arduino no tiene una configuracion: nunca deberia suceder");
            else if(arduino.ConfigurationCrop.Crop == null)
                throw new EntityNullException("extraño: el cultivo no existe: nunca deberia suceder");
            else if (arduino.ConfigurationCrop.Crop.CoffeeGrower == null)
                throw new EntityNullException("extraño: el CoffeeGrower no existe: nunca deberia suceder");
            else if(arduino.ConfigurationCrop.Crop.CoffeeGrower.Id != coffeeGrowerId)
                throw new EntityNullException("este arduino no pertenece al usuario del token enviado");

            //creamos el nuevo arduino para reemplazarlo con el actual: ocupado = verdadero
            var newArduino = (Arduino)this.factory.CreateArduino(name: arduino.Name, 
                configurationCropId: arduino.ConfigurationCropId, id: Guid.Parse(arduino.Id), 
                occupied: true);

            //crear el evento en el que se sincronizo el arduino.
            var ArduinoEvent = this.autoMapping.Map<Arduino, ArduinoSyncUpEvent>(newArduino);
            ArduinoEvent.CropId = arduino.ConfigurationCrop.CropId;
            await this.eventPublisher.PublishEventAsync(ArduinoEvent);

            //modificamos, mapeamos y retornamos el arduino
            return this.autoMapping.Map<Arduino, ArduinoSyncUpDTO>(await this.repository.Update<Arduino>(newArduino, cancellationToken));
        }
    }
}
