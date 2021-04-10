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

namespace Cafe.Configuration.Application.CropServices.CommandCropCreate
{
    public class CropCreateHandler : IRequestHandler<CropCreate, CropCreateDTO>
    {
        private readonly IRepository repository;

        private readonly IFactory factory;

        private readonly IAutoMapping autoMapping;

        public CropCreateHandler(IRepository repository, IFactory factory, IAutoMapping autoMapping)
        {
            this.autoMapping = autoMapping;
            this.factory = factory;
            this.repository = repository; ;
        }

        public async Task<CropCreateDTO> Handle(CropCreate request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("la peticion es nula al crear el cultivo.");

            var coffeeGrowerIdPresent = request.Claims.Find(x => x.Type == "CoffeeGrowerId").Value;
            if(coffeeGrowerIdPresent == null)
                throw new ArgumentNullException("en el token enviado no se pudo recuperar el id del caficultor");
            else if (request.CoffeeGrowerId != coffeeGrowerIdPresent)
                throw new ArgumentDifferentException("el id del caficultor y el token que contine el id del cadicultor no son iguales.");

            var crop = (Crop) this.factory.CreateCrop(request.Name, request.DayFormation, request.CoffeeGrowerId);

            return autoMapping.Map<Crop, CropCreateDTO>(await this.repository.Save<Crop>(crop, cancellationToken));
        }
    }
}
