using Cafe.Configuration.Application.CropServices.CommandCropCreate;
using Cafe.Configuration.Application.CropServices.QueryCropById;
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
using System.Web.Providers.Entities;

namespace Cafe.Web.Api.Configuration
{
    [Route("api/[controller]")]
    [ApiController]
    public class CultivoConfiguracionController : ControllerBase
    {
        private readonly IMediator mediator;

        public CultivoConfiguracionController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPut]
        [Route("cultivo")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CrearCultivo([FromBody] CropCreate cropCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            List<Claim> claims = User.Claims.ToList();
            if (claims == null)
                return BadRequest("no se pudieron obtener los claims del token, verifique el token.");

            cropCreate.Claims = claims;
            var dto = await this.mediator.Send(cropCreate);

            if (dto == null)
                return BadRequest("no se pudo crear el cultivo.");
            else
                return Ok(dto);
        }

        [HttpGet]
        [Route("cultivo")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ObtenerCultivo([FromBody] CropById cropById)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            List<Claim> claims = User.Claims.ToList();
            if (claims == null)
                return BadRequest("no se pudieron obtener los claims del token, verifique el token.");

            cropById.Claims = claims;
            var dto = await this.mediator.Send(cropById);

            if (dto == null)
                return BadRequest("no se pudo obtener el cultivo");
            else
                return Ok(dto);
        }

        [HttpGet]
        [Route("cultivos")]
        public async Task<IActionResult> ObtenerCultivos(string idCultivo)
        {
            return await Task.FromResult(Ok($"cultivo creado: {idCultivo}"));
        }

        [HttpPost]
        [Route("Temperatura")]
        public async Task<IActionResult> ConfigurarTemperatura(string idCultivo, double minimoUmbralDesarrolloInsecto, 
            double maximoUmbralDesarrolloInsepto, double gradoMinimoEfectivo)
        {
            return await Task.FromResult(Ok($"cultivo creado: {idCultivo} {minimoUmbralDesarrolloInsecto} " +
                $"{maximoUmbralDesarrolloInsepto} {gradoMinimoEfectivo}"));
        }

        /// <summary>
        /// comienza a monitorear el cultivo, tener en cuenta que si la brocaDetectada es true no hay necesidad de subir inmagen
        /// </summary>
        /// <param name="idCultivo"></param>
        /// <param name="brocaDetectadaResientemente"></param>
        /// <param name="urlImagen"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Monitor")]
        public async Task<IActionResult> ComenzarMonitoreo(string idCultivo, bool brocaDetectadaResientemente, string urlImagenFrutoBrocado)
        {
            return await Task.FromResult(Ok($"comenzar: {idCultivo} {urlImagenFrutoBrocado} {brocaDetectadaResientemente}"));
        }

        /// <summary>
        /// identifica el arduino, esta api es para el arduino
        /// </summary>
        /// <param name="IdCultivo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Identificador")]
        public async Task<IActionResult> IdentificarArduino(string idArduino)
        {
            return await Task.FromResult(Ok($"cultivo creado: {idArduino}"));
        }
    }
}
