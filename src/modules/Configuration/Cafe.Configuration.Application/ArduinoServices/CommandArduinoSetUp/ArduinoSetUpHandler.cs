using Cafe.Configuration.Application.Exceptions;
using Cafe.Configuration.Domain.Entities;
using Cafe.Configuration.Domain.Factories;
using Cafe.Configuration.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Configuration.Application.ArduinoServices.CommandArduinoSetUp
{
    /// <summary>
    /// importante: si no existe la configuracion se debera crear y tambien el arduino
    /// si existe la configuracion pero no el arduino, entonces, se debera crear el arduino y asignarle esa configuracion
    /// no puede existir el arduno sin configuracion 
    /// si puede exister la configuracion sin arduino
    /// </summary>
    public class ArduinoSetUpHandler : IRequestHandler<ArduinoSetUp, ArduinoSetUpDTO>
    {
        private readonly IRepository repository;

        private readonly IFactory factory;

        private readonly IAutoMapping autoMapping;

        public ArduinoSetUpHandler(IRepository repository, IFactory factory, IAutoMapping autoMapping)
        {
            this.autoMapping = autoMapping;
            this.factory = factory;
            this.repository = repository;
        }


        public async Task<ArduinoSetUpDTO> Handle(ArduinoSetUp request, CancellationToken cancellationToken)
        {
            //argumentos
            if (request == null)
                throw new ArgumentNullException("la peticion para configurar el arduno es nula.");

            //verificamos el token y el caficultor
            var coffeeGrowerId = request.Claims.Find(x => x.Type == "CoffeeGrowerId").Value;
            if (coffeeGrowerId == null)
                throw new TokenException("no se pudo recuperar el id del caficultor con el token enviado.");
            else if(! this.repository.Exists<CoffeeGrower>(x => x.Id == coffeeGrowerId))
                throw new EntityNullException("el caficultor no existe de acurdo al token enviado.");

            //obtenemos el cultivo y verificamos
            var crop = await repository.GetWithNestedObject<Crop>(x => x.Id == request.CropId, x => x.ConfigurationCrop.Arduino, cancellationToken);
            ConfigurationCrop configurationCrop = crop.ConfigurationCrop;
            Arduino arduino = configurationCrop.Arduino;

            if (crop == null)
            {
                throw new EntityNullException("no se pudo recuperar el cultivo. verificar el id envido");
            } 
            else if (crop.CoffeeGrowerId != coffeeGrowerId)
            {
                throw new ArgumentDifferentException("el id del caficultor no coincide con el id del caficultor que se envio en el toeken");
            }   
            else if(configurationCrop == null)
            {
                configurationCrop = (ConfigurationCrop) this.factory.CreateConfigurationCrop(crop.Id);
            }
            
            if(arduino == null)
            {
                arduino = (Arduino)this.factory.CreateArduino(request.Name, configurationCrop.Id, configurationCrop); //resisar la asignacion de configurationCrop cuando ya existe
            }
            else if(this.repository.Exists<Arduino>(x => x.Id == crop.ConfigurationCrop.Arduino.Id) == true)
            {
                throw new DuplicityEntityException("el cultivo ya tiene una configuracion de arduino creada.");
            }

            //crear, guardar, mapear y retornar un arduino
            return this.autoMapping.Map<Arduino, ArduinoSetUpDTO>(await this.repository.Save<Arduino>(arduino, cancellationToken));
        }
    }
}
