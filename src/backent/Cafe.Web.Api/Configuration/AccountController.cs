using Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerLogin;
using Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerSignIn;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Web.Api.Configuration
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        private readonly IConfiguration configuration;

        public AccountController(IMediator mediator, IConfiguration configuration)
        {
            this.mediator = mediator;
            this.configuration = configuration;
        }

        [Route("Cuenta")]
        [HttpPost]
        public async Task<IActionResult> CreateAcount([FromBody] CoffeeGrowerSignIn coffeGrowerSignIn)
        {
            if(!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            var dto = await mediator.Send(coffeGrowerSignIn);
            if (dto == null)
                return BadRequest("no se pudo crear la cuenta.");
            else
                return Ok(dto);
        }

        [Route("Logear")]
        [HttpPost]
        public async Task<IActionResult> Logearse([FromBody] CoffeGrowerLogin coffeGrowerLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            var dto = await this.mediator.Send(coffeGrowerLogin);
            if (dto == null)
                return BadRequest("no se pudo logear el usuario.");
            else
                return Ok(dto);
        }

    }
}
