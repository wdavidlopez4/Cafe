using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerSignIn
{
    public class CoffeeGrowerSignIn : IRequest<CoffeeGrowerSignInDTO>
    {
        public string Name { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }
    }
}
