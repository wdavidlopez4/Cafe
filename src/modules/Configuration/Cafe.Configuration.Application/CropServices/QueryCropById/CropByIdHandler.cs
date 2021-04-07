using Cafe.Configuration.Domain.Entities;
using Cafe.Configuration.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Configuration.Application.CropServices.QueryCropById
{
    public class CropByIdHandler : IRequestHandler<CropById, CropByIdDTO>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        private readonly IUserSecurity userSecurity;

        public CropByIdHandler(IRepository repository, IAutoMapping autoMapping, IUserSecurity userSecurity)
        {
            this.autoMapping = autoMapping;
            this.repository = repository;
            this.userSecurity = userSecurity;
        }

        public async Task<CropByIdDTO> Handle(CropById request, CancellationToken cancellationToken)
        {
            //verificar la peticion
            if (request == null)
                throw new ArgumentNullException("la peticion para recuperar el cultivo es nula");

            //obtener el id del caficultor del token que me enviaron
            var coffeeGowerIdPresent =  request.Claims.Find(x=> x.Type == "CoffeeGrowerId").Value;
            if (coffeeGowerIdPresent == null)
                throw new Exception("no se pudo recuperar el id del claim");

            //obtener el cultivo con el caficultor
            var crop = await this.repository.GetWithNestedObject<Crop>(x => x.Id == request.Id, x => x.CoffeeGrower, cancellationToken);
            if(crop == null)
                throw new Exception("no se pudo recuperar el cultivo con el id enviado.");

            //descodificar el token del caficultor que se obtuvo para obtener el id del caficultor
            string CoffeeGrowerIdDb = this.userSecurity.GetClaim(crop.CoffeeGrower.Token, "CoffeeGrowerId");

            //comprar tanto el id del token que se envio con el token de la db y si es correcto enviar el cultivo
            if (CoffeeGrowerIdDb != coffeeGowerIdPresent)
                throw new Exception("el id del caficultor no correcponde al id que se almaceno en clam del token");
            return autoMapping.Map<Crop, CropByIdDTO>(crop);
        }
    }
}
