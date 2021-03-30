using Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerCreate;
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
        public async Task<IActionResult> CreateAcount([FromBody] CoffeeGrowerCreate coffeGrowerCreate)
        {
            if(!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");
            else
            {
                var dto = await mediator.Send(coffeGrowerCreate);
                if (dto == null)
                    return BadRequest("no se pudo crear la cuenta.");
                else
                {
                    return this.CreateToken(dto);
                }
            }
        }

        [Route("Logear")]
        [HttpPost]
        public async Task<IActionResult> Logearse([FromBody] string correo, string contraseña)
        {
            return await Task.FromResult(Ok($"logeado: {correo}, {contraseña}"));
        }

        /// <summary>
        /// creacion del token
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        private IActionResult CreateToken(CoffeeGrowerCreateDTO dto)
        {
            //creamos el cleims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, dto.Mail),
                new Claim(JwtRegisteredClaimNames.NameId, dto.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("nombre", dto.Name)
            };

            //creamos la clave la cual tendra una variable de ambiente "Clave secreta" tambien la credencial y el expide
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["CLAVE_SECRETA"]));
            if (key == null)
                return BadRequest("la clave de seguridad nunca se instancio...");

            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issues = DateTime.UtcNow.AddDays(15); //expide

            //creamos el token con los datos anteriores
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "dominio web",
                audience: "dominio web",
                claims: claims,
                expires: issues,//expide
                signingCredentials: credential
                );

            //retornamos el token y el expide del token
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = issues
            });
        }
    }
}
