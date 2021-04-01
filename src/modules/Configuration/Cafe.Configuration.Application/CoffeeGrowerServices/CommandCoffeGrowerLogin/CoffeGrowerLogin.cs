using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerLogin
{
    public class CoffeGrowerLogin : IRequest<CoffeGrowerLoginDTO>
    {
        public string Mail { get; set; }

        public string Password { get; set; }
    }
}
