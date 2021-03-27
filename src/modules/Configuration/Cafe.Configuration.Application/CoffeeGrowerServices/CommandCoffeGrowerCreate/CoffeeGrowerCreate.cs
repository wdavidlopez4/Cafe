using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerCreate
{
    public class CoffeeGrowerCreate : IRequest<CoffeeGrowerCreateDTO>
    {
        public string Name { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }
    }
}
