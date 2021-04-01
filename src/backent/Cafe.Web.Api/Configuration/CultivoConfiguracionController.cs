using Cafe.Configuration.Application.CropServices.CommandCropCreate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> CrearCultivo([FromBody] CropCreate cropCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            var dto = await this.mediator.Send(cropCreate);
            if (dto == null)
                return BadRequest("no se pudo crear el cultivo.");
            else
                return Ok(dto);
        }

        [HttpGet]
        [Route("cultivo")]
        public async Task<IActionResult> ObtenerCultivo(string idCultivo)
        {
            return await Task.FromResult(Ok($"cultivo creado: {idCultivo}"));
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
