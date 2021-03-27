using Cafe.Configuration.Domain.Entities;
using Cafe.Configuration.Domain.Factories;
using Cafe.Configuration.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerCreate
{
    public class CoffeeGrowerCreateHandler : IRequestHandler<CoffeeGrowerCreate, CoffeeGrowerCreateDTO>
    {
        private readonly IFactory factory;

        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        public CoffeeGrowerCreateHandler(IFactory factory, IRepository repository, IAutoMapping autoMapping)
        {
            this.repository = repository;
            this.factory = factory;
            this.autoMapping = autoMapping;
        }

        public async Task<CoffeeGrowerCreateDTO> Handle(CoffeeGrowerCreate request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("es nulo el comando del caficultor");

            try
            {
                //creamos la entidad
                var coffeeGrower = (CoffeeGrower)this.factory.CreateCoffeeGrower(name: request.Name, mail: request.Mail, password: request.Password);

                //guardamos la entidad
                var rest = await repository.Save<CoffeeGrower>(coffeeGrower, cancellationToken);

                //maperar la imagen
                return autoMapping.Map<CoffeeGrower, CoffeeGrowerCreateDTO>(rest);
                
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
