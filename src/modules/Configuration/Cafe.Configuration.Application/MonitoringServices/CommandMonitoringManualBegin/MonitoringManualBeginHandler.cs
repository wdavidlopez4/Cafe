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

namespace Cafe.Configuration.Application.MonitoringServices.CommandMonitoringManualBegin
{
    public class MonitoringManualBeginHandler : IRequestHandler<MonitoringManualBegin, MonitoringManualBeginDTO>
    {
        private readonly IRepository repository;

        private readonly IFactory factory;

        private readonly IAutoMapping autoMapping;

        public MonitoringManualBeginHandler(IRepository repository, IFactory factory, IAutoMapping autoMapping)
        {
            this.autoMapping = autoMapping;
            this.factory = factory;
            this.repository = repository;
        }

        public async Task<MonitoringManualBeginDTO> Handle(MonitoringManualBegin request, CancellationToken cancellationToken)
        {
            //verificamos peticion y datos enviados
            if (request == null)
                throw new ArgumentNullException("la peticion para obtener la configuracion es nula");

            var coffeeGrowerId = request.Claims.Find(x => x.Type == "CoffeeGrowerId").Value;
            if (coffeeGrowerId == null)
                throw new TokenException("no se pudo recuperar el claim id del caficultor con el token enviado.");

            else if (!this.repository.Exists<CoffeeGrower>(x => x.Id == coffeeGrowerId))
                throw new EntityNullException("no se pudo encontrar el caficultor con el token enviado.");


            //verificar que el cultivo este listo para comenzar a monitorear
            var crop = await CheckCrop(request.CropId, coffeeGrowerId, cancellationToken);

            //verificamos que la configuracion este lista para comenzar a monitoriar
            await CkeckConfigurationCrop(crop.ConfigurationCrop.Id, cancellationToken);

            //creamos, guardamo y retornamos el monitoreo
            var manual = (ManualMonitoring)this.factory.CreateMonitoring(request.ActivateManually, crop.Id);

            return this.autoMapping.Map<ManualMonitoring, MonitoringManualBeginDTO>(
                await this.repository.Save<ManualMonitoring>(manual, cancellationToken));

        }

        /// <summary>
        /// verificamos que el cultivo este listo para comenzar a monitoriar: 
        /// si es nulo, si el id del caficultor corresponde al token,
        /// si la configuracion es nula, si el monitoreo ya existe
        /// </summary>
        /// <param name="requestIdCrop"></param>
        /// <param name="coffeeGrowerId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<Crop> CheckCrop(string requestIdCrop, string coffeeGrowerId, CancellationToken cancellationToken)
        {
            if (!this.repository.Exists<Crop>(x => x.Id == requestIdCrop))
                throw new EntityNullException("no se pudo encontrar el cultivo con el id enviado.");

            //traemos el cultivo y lo necesario para verificarlo
            var crop = await this.repository.GetWithNestedObjects<Crop>(cancellationToken,
                x => x.Id == requestIdCrop,
                x => x.CoffeeGrower,
                x => x.ConfigurationCrop,
                x => x.Monitoring);

            if (crop == null)
            {
                throw new EntityNullException("no se pudo recuperar el cultivo");
            }
            else if (crop.CoffeeGrowerId != coffeeGrowerId)
            {
                throw new ArgumentDifferentException("esta tratando de recuperar un cultivo que no le pertenece al caficultor.");
            }
            else if (crop.ConfigurationCrop == null)
            {
                throw new EntityNullException("aun no se a realizo la configuracion para el cultivo");
            }
            else if (crop.Monitoring != null)
            {
                throw new MonitoringRunningException("ya existe una entidad ejecutando el monitoreo del cultivo. " +
                    "compruebe si esta entidad esta detenida o no, y vuelva a ejecutarla si es necesatio");
            }
            else if(crop.DayFormation == 0)
            {
                throw new ArgumentIgualsException("el dia de formacion es igual a 0, " +
                    "No se pude comenzar a monitoriar si la formacion aun no a comenzado");
            }

            return crop;
        }

        /// <summary>
        /// verificamos que la configuracion este lista para comenzar a monitoriar;
        /// que la configuracion no sea nula, tanto la temperatura y el arduino sean nulos
        /// y que el arduno ya este sincronizado
        /// </summary>
        /// <param name="configurationId"></param>
        /// <param name="cancellationToken"></param>
        private async Task<ConfigurationCrop> CkeckConfigurationCrop(string configurationId, CancellationToken cancellationToken)
        {
            var configurationCrop = await this.repository.GetWithNestedObjects<ConfigurationCrop>(cancellationToken,
                x => x.Id == configurationId,
                x => x.Arduino,
                x => x.Temperature);

            if (configurationCrop == null)
                throw new EntityNullException("no se pudo extraer la configuracion del cultivo.");
            else if (configurationCrop.Temperature == null || configurationCrop.Arduino == null)
                throw new EntityNullException("no se ha terminado de configurar el cultivo");
            else if (configurationCrop.Arduino.Occupied == false)
                throw new EntityNullException("no se ha sincronizado el arduino.");

            return configurationCrop;
        }
    }
}
