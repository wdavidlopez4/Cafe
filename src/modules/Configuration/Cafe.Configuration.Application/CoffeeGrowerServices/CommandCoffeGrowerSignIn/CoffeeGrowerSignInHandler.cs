using Cafe.Configuration.Domain.Entities;
using Cafe.Configuration.Domain.Factories;
using Cafe.Configuration.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerSignIn
{
    public class CoffeeGrowerSignInHandler : IRequestHandler<CoffeeGrowerSignIn, CoffeeGrowerSignInDTO>
    {
        private readonly IFactory factory;

        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        private readonly IUserSecurity userSecurity;

        public CoffeeGrowerSignInHandler(IFactory factory, IRepository repository, IAutoMapping autoMapping, IUserSecurity userSecurity)
        {
            this.repository = repository;
            this.factory = factory;
            this.autoMapping = autoMapping;
            this.userSecurity = userSecurity;
        }

        public async Task<CoffeeGrowerSignInDTO> Handle(CoffeeGrowerSignIn request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("es nulo el comando del caficultor");
            else if (this.repository.Exists<CoffeeGrower>(x => x.Mail == request.Mail))
                throw new Exception("la cuenta de usuario ya existe");

            //creamos datos necesarios para el caficultor
            var id = Guid.NewGuid();
            var token = userSecurity.CreateToken(request.Mail, id, request.Name);
            var encriptPassword = userSecurity.EncriptAndCkeckPassword(request.Password);
            if (token == null || encriptPassword == null)
                throw new Exception("no se pudo generar el token o encriptar la contraseña.");

            //creamos la entidad
            var coffeeGrower = (CoffeeGrower)this.factory.CreateCoffeeGrower(name: request.Name, mail: request.Mail, 
                password: encriptPassword, token: token, id: id);

            //guardamos la entidad
            var rest = await repository.Save<CoffeeGrower>(coffeeGrower, cancellationToken);

            //maperar la imagen
            return autoMapping.Map<CoffeeGrower, CoffeeGrowerSignInDTO>(rest);
        }
    }
}
