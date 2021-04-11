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

namespace Cafe.Configuration.Application.SetUpServices.QuerySetUpByIdCrop
{
    public class SetUpByIdCropHandler : IRequestHandler<SetUpByIdCrop, SetUpByIdCropDTO>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        public SetUpByIdCropHandler(IRepository repository, IAutoMapping autoMapping)
        {
            this.autoMapping = autoMapping;
            this.repository = repository;
        }

        public async Task<SetUpByIdCropDTO> Handle(SetUpByIdCrop request, CancellationToken cancellationToken)
        {
            //verificamos la peticion
            if (request == null)
                throw new ArgumentNullException("la peticion para obtener la configuracion es nula");

            //verificamos el caficultor: claim y existencia
            var coffeeGrowerId =request.Claims.Find(x => x.Type == "CoffeeGrowerId").Value;
            if (coffeeGrowerId == null)
            {
                throw new TokenException("no se pudo recuperar el id del caficultor con el token enviado");
            }
            else if (this.repository.Exists<CoffeeGrower>(x => x.Id == coffeeGrowerId) == false)
            {
                throw new EntityNullException("no se pudo encontrar el caficultor con el id del token enviado");
            }

            //obtenemos el cultivo y verificamos: si existe mas la configuracion
            var crop = await this.repository.GetWithNestedObject<Crop>(x => x.Id == request.CropId, 
                x => x.ConfigurationCrop, cancellationToken);
            if(crop == null)
            {
                throw new EntityNullException("segun el id del cultivo, el caficultor no posee ese cultivo");
            }
            else if (crop.ConfigurationCrop == null)
            {
                throw new EntityNullException("el cultivo aun no tiene ninguna configuracion");
            }

            //obtener la configuracion, mapear y retornar
            var configurationCrop = await this.repository.GetWithNestedObjects<ConfigurationCrop>(cancellationToken, 
                x => x.Id == crop.ConfigurationCrop.Id,
                x => x.Temperature,
                x => x.Arduino,
                x => x.Crop);

            return this.autoMapping.Map<ConfigurationCrop, SetUpByIdCropDTO>(configurationCrop);
        }

    }
}
