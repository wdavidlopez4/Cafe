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

namespace Cafe.Configuration.Application.MonitoringServices.CommandMonitoringImageBegin
{
    public class MonitoringImageBeginHandler : IRequestHandler<MonitoringImageBegin, MonitoringImageBeginDTO>
    {
        private readonly IRepository repository;

        private readonly IFactory factory;

        private readonly IAutoMapping autoMapping;

        public MonitoringImageBeginHandler(IRepository repository, IFactory factory, IAutoMapping autoMapping)
        {
            this.autoMapping = autoMapping;
            this.factory = factory;
            this.repository = repository;
        }

        public async Task<MonitoringImageBeginDTO> Handle(MonitoringImageBegin request, CancellationToken cancellationToken)
        {
            //verificamos los parametoros
            if (request == null)
                throw new ArgumentNullException("la peticion para monitorear el cultivo es nula.");

            var coffeeGrowerId = request.Claims.Find(x => x.Type == "CoffeeGrowerId").Value;
            if (coffeeGrowerId == null)
                throw new TokenException("no es posible extraer el id del token del caficultor");

            else if (! this.repository.Exists<CoffeeGrower>(x => x.Id == coffeeGrowerId))
                throw new EntityNullException("el caficultor no se encontro con el token proporcionado");


            //verificamos el cultivo, que este listo para comenzar a monitorear
            var crop = await CheckCrop(request.CropId, coffeeGrowerId, cancellationToken);

            // verificar que la configuracion del cultivo este lista para comenzar a monitoriarse
            var configurationCrop = await this.CheckConfigurationCrop(crop.ConfigurationCrop.Id, cancellationToken);

            //verificar la codificacion de la imagen
            if (! IsBase64String(request.ActivateByImage))
                throw new EncriptException("la url de la imagen no esta en base 64.");

            //crear, guardar, mapear y retornar el monitoreo
            var monitoring = (ImageMonitoring) this.factory.CreateMonitoring(request.ActivateByImage, true, crop.Id);

            return this.autoMapping.Map<ImageMonitoring, MonitoringImageBeginDTO>(
                await this.repository.Save<ImageMonitoring>(monitoring, cancellationToken));
        }

        /// <summary>
        /// verificamos que el cultivo este listo para comenzar a monitorearse
        /// </summary>
        /// <param name="requestCropId"></param>
        /// <param name="coffeeGrowerid"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<Crop> CheckCrop(string requestCropId, string coffeeGrowerid, 
            CancellationToken cancellationToken)
        {
            if (! this.repository.Exists<Crop>(x => x.Id == requestCropId))
                throw new EntityNullException("el cultivo no se encontro con el id proporcionado");

            var crop = await this.repository.GetWithNestedObjects<Crop>(cancellationToken, 
                x => x.Id == requestCropId, 
                x => x.CoffeeGrower,
                x => x.ConfigurationCrop,
                x => x.Monitoring);

            if (crop == null)
                throw new EntityNullException("no se pudo extraer el cultivo.");

            else if (crop.CoffeeGrowerId != coffeeGrowerid)
                throw new ArgumentDifferentException("el id del cultivo enviado no es igual al id del cultivo recuperado " +
                    "con los datos del token ");

            else if (crop.ConfigurationCrop == null)
                throw new EntityNullException("aun no se a configurado el cultivo.");

            else if (crop.Monitoring != null)
                throw new MonitoringRunningException("ya existe una entidad que esta monitoreando el ciltivo.");

            else if(crop.DayFormation == 0)
                throw new MonitoringRunningException("el cultivo aun no tiene dias de formacion, su formacion es 0");

            return crop;
        }

        /// <summary>
        /// verifica si la configuracion esta lista para comenzar a monitorizar el cultivo
        /// </summary>
        /// <param name="configurationCropid"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<ConfigurationCrop> CheckConfigurationCrop(string configurationCropid, CancellationToken cancellationToken)
        {
            if(! this.repository.Exists<ConfigurationCrop>(x => x.CropId == configurationCropid))
                throw new EntityNullException("el cultivo aun no tiene configuracion");

            var configuration = await this.repository.GetWithNestedObjects<ConfigurationCrop>(cancellationToken, 
                x => x.Id == configurationCropid, 
                x => x.Arduino,
                x => x.Temperature);

            if (configuration == null)
                throw new EntityNullException("no se pudo recuperar la configuracion");

            else if(configuration.Temperature == null)
                throw new EntityNullException("aun no se a configurado la temperatura");

            else if(configuration.Arduino == null)
                throw new EntityNullException("aun no se a configurado el arduino");

            return configuration;
        }

        /// <summary>
        ///verificar si es string es base 64
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        private static bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
        }
    }
}
