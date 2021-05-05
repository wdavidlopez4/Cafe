using Cafe.Climate.Application.ArduinoServices.CommandArduinoSetData;
using Cafe.Climate.Application.ArduinoServices.QueryArduinoByRangeTime;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cafe.Web.Api.Climate
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimateController : ControllerBase
    {
        private readonly IMediator mediator;

        public ClimateController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        [Route("DatosClimaticos")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CrearDatosClimaticos([FromBody] ArduinoDataSet arduinoDataSet)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            List<Claim> claims = User.Claims.ToList();
            if (claims == null)
                return BadRequest("no se pudieron obtener los claims del token, verifique el token.");

            arduinoDataSet.Claims = claims;
            var dto = await this.mediator.Send(arduinoDataSet);

            if (dto == null)
                return BadRequest("no se pudo crear el cultivo.");
            else
                return Ok(dto);
        }

        [HttpGet]
        [Route("DatosClimativosRangoFecha")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ObtenerListaDeDatosClimaticosEnRangoFecha([FromBody] ArduinoByRangeTime arduinoByRangeTime)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            List<Claim> claims = User.Claims.ToList();
            if (claims == null)
                return BadRequest("no se pudieron obtener los claims del token, verifique el token.");

            arduinoByRangeTime.Claims = claims;
            var dto = await this.mediator.Send(arduinoByRangeTime);

            if (dto == null)
                return BadRequest("no se pudo crear el cultivo.");
            else
                return Ok(dto);
        }

        [HttpGet]
        [Route("DatosClimativosRangoFechaCampos")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ObtenerListaDeDatosClimaticosEnRangoFecha(
            [Bind("cropId,rangeTimelower,rangeTimeUpper")] string cropId, DateTime rangeTimelower, DateTime rangeTimeUpper)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            List<Claim> claims = User.Claims.ToList();
            if (claims == null)
                return BadRequest("no se pudieron obtener los claims del token, verifique el token.");

            var dto = await this.mediator.Send(new ArduinoByRangeTime 
            { 
                CropId = cropId, 
                RangeTimelower = rangeTimelower,
                RangeTimeUpper = rangeTimeUpper,
                Claims = claims
            });

            if (dto == null)
                return BadRequest("no se pudo crear el cultivo.");
            else
                return Ok(dto);
        }
    }
}
