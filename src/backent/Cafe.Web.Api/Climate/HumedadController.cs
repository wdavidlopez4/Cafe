using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe.Web.Api.Climate
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumedadController : ControllerBase
    {
        [Route("Emergencia")]
        [HttpGet]
        public async Task<IActionResult> CalcularEmergenciaBroca(string idCultivo)
        {
            return await Task.FromResult(Ok($"emergencia: {idCultivo}"));
        }

        [Route("Fecundidad")]
        [HttpGet]
        public async Task<IActionResult> CalcularIndiceFecundidad(string idCultivo)
        {
            return await Task.FromResult(Ok($"fecundidad: {idCultivo}"));
        }

        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> ObtenerHumedad(string idCultivo)
        {
            return await Task.FromResult(Ok($"humedad: {idCultivo}"));
        }

        [Route("Post")]
        [HttpPost]
        public async Task<IActionResult> PostArduino(double humedad)
        {
            return await Task.FromResult(Ok($"humedad: {humedad}"));
        }
    }
}
