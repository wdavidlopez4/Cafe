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
    public class AltitudController : ControllerBase
    {
        /// <summary>
        /// el frontend recupera el estado propicio de desarrollo, le pasamos el Id del cultivo
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [Route("EstadoPropicioInsepto")]
        [HttpGet]
        public async Task<IActionResult> CalcularDesarrolloPropicioInsepto(string idCultivo)
        {
            return await Task.FromResult(Ok($"propicio: {idCultivo}"));
        }

        /// <summary>
        /// el frontend recupera la altitud, le pasamos el id del cultivo
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> ObtenerAltitud(string idCultivo)
        {
            return await Task.FromResult(Ok($"altitud: {idCultivo}"));
        }

        /// <summary>
        /// el arduino envia la temperatura
        /// </summary>
        /// <param name="temperatura"></param>
        /// <param name="humedad"></param>
        /// <returns></returns>
        [Route("Post")]
        [HttpPost]
        public async Task<IActionResult> PostArduino(double temperatura, double humedad)
        {
            return await Task.FromResult(Ok($"{temperatura}, {humedad}"));
        }
    }
}
