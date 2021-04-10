using Cafe.Configuration.Domain.Entities;
using Cafe.Configuration.Domain.Factories;
using Cafe.Configuration.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerLogin
{
    public class CoffeGrowerLoginHandler : IRequestHandler<CoffeGrowerLogin, CoffeGrowerLoginDTO>
    {
        private readonly IFactory factory;

        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        private readonly IUserSecurity userSecurity;

        public CoffeGrowerLoginHandler(IFactory factory, IRepository repository, IAutoMapping autoMapping, IUserSecurity userSecurity)
        {
            this.repository = repository;
            this.factory = factory;
            this.autoMapping = autoMapping;
            this.userSecurity = userSecurity;
        }

        public async Task<CoffeGrowerLoginDTO> Handle(CoffeGrowerLogin request, CancellationToken cancellationToken)
        {
            //verificamos que la peticion es correcta
            if (request == null)
                throw new ArgumentNullException("la peticion para loguerase es nula");

            else if (string.IsNullOrWhiteSpace(request.Mail) || string.IsNullOrWhiteSpace(request.Password))
                throw new ArgumentNullException("contraseña o correo son nulos.");

            else if(! repository.Exists<CoffeeGrower>(x => x.Mail == request.Mail))
                throw new ArgumentNullException("no se puede loquear por que el usuario no existe.");


            //obtenemos el caficultor, creamos un nuevo token y encriptamos la contraseña para luego contararlas
            var coffeeGrower = await this.repository.Get<CoffeeGrower>(x => x.Mail == request.Mail, cancellationToken);
            var newToken = userSecurity.CreateToken(coffeeGrower.Mail, Guid.Parse(coffeeGrower.Id), coffeeGrower.Name);
            var encriptResquestPassword = userSecurity.EncriptAndCheckPassword(request.Password);


            //verificamos la contraseña y el nuevo token
            if (string.IsNullOrWhiteSpace(encriptResquestPassword))
                throw new ArgumentNullException("des-encriptacion incorrecta.");

            else if(encriptResquestPassword != coffeeGrower.Password)
                throw new ArgumentNullException("la contraseñas son incorrectas.");

            else if (string.IsNullOrWhiteSpace(newToken))
                throw new ArgumentNullException("el token no se pudo generar.");


            //fabricamos el new caficultor para luego actualizarlo y posteriormente maperar a un dto para luego retornarlo
            var newCoffeeGrower = (CoffeeGrower)this.factory.CreateCoffeeGrower(name: coffeeGrower.Name, 
                mail: coffeeGrower.Mail, password: coffeeGrower.Password, token: newToken, id: Guid.Parse(coffeeGrower.Id));

            return autoMapping.Map<CoffeeGrower, CoffeGrowerLoginDTO>(await repository.Update<CoffeeGrower>(newCoffeeGrower, cancellationToken));

        }
    }
}
