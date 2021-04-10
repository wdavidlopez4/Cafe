using Cafe.Configuration.Application.Exceptions;
using Cafe.Configuration.Domain.Entities;
using Cafe.Configuration.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Configuration.Application.CropServices.QueryCropByPage
{
    public class CropByPageHandler : IRequestHandler<CropByPage, List<CropByPageDTO>>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        public CropByPageHandler(IRepository repository, IAutoMapping autoMapping)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
        }

        public async Task<List<CropByPageDTO>> Handle(CropByPage request, CancellationToken cancellationToken)
        {
            //verificamos la peticion
            if (request == null)
                throw new ArgumentNullException("peticion para consultar por rango es nula.");

            //obtenemos el claim que en este caso es el id del caficultor y verificamos que el campo no sea null
            var coffeeGrowerIdPresent = request.Claims.Find(x => x.Type == "CoffeeGrowerId").Value;
            if (string.IsNullOrWhiteSpace(coffeeGrowerIdPresent))
                throw new ArgumentNullException("no se pudo recuperar el id del caficultor del token proporcionado");

            //obtenemos los cultivos
            var crops = await this.repository.GetAllBy<Crop>(x => x.Name, request.PageNumber, request.PageSize,
                x => x.CoffeeGrower,x => x.CoffeeGrowerId == coffeeGrowerIdPresent, cancellationToken);
            if (crops == null)
                throw new EntityNullException("la lista de cultivos nunca se creo.");

            //retornamos
            return this.autoMapping.Map<List<Crop>, List<CropByPageDTO>>(crops);
        }
    }
}
