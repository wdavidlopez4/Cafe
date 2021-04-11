using Cafe.Configuration.Application.ArduinoServices.CommandArduinoSetUp;
using Cafe.Web.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cafe.Web.Api.Configuration
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManagerConfigurationFilter))]
    public class ArduinoConfigurationController : ControllerBase
    {
        private readonly IMediator mediator;

        public ArduinoConfigurationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// configurar el arduino desde la UI
        /// </summary>
        /// <param name="arduinoSetUp"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Arduino")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ConfigurarArduino([FromBody] ArduinoSetUp arduinoSetUp)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            List<Claim> claims = User.Claims.ToList();
            if (claims == null)
                return BadRequest("no se pudieron obtener los claims del token, verifique el token.");

            arduinoSetUp.Claims = claims;
            var dto = await this.mediator.Send(arduinoSetUp);

            if (dto == null)
                return BadRequest("no se pudo crear el cultivo.");
            else
                return Ok(dto);
        }

        /// <summary>
        /// sincronizar el arduino SOLO PARA EL ARDUINO
        /// </summary>
        /// <param name="idArduino"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Sincronizar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SincronozarArduino(string idArduino)
        {
            return Ok(await Task.FromResult(""));
        }
    }
}
