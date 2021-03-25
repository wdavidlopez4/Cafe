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
    public class TemperaturaController : ControllerBase
    {
        /// <summary>
        /// calcula los grados acumulados para el desarrollo del insepto se denota como K, se consulta cada 24 horas para moscar cambios
        /// le pasamos el id del cultivo, y la fecha de consulta actual
        /// </summary>
        /// <param name="cultivoDto"></param>
        /// <returns></returns>
        [Route("K")]
        [HttpGet]
        public async Task<IActionResult> CalcularGradosAcumuladosInsepto(string idCultivo, DateTime fechaConsultaActual)
        {
            return await Task.FromResult(Ok($"Grados acumulados: {idCultivo} {fechaConsultaActual}"));
        }

        /// <summary>
        /// calcular grados dias, se consulta cada 24 horas para mostrar cambios
        /// le pasamos el id del cultivo y la fecha de la consulta actual
        /// </summary>
        /// <param name="cultivoDto"></param>
        /// <returns></returns>
        [Route("GradosDia")]
        [HttpGet]
        public async Task<IActionResult> CalcularGradosDia(string idCultivo, DateTime fechaConsultaActual)
        {
            return await Task.FromResult(Ok($"Grados dia: {idCultivo} {fechaConsultaActual}"));
        }

        /// <summary>
        /// calcula el minimo y maximo umbral de desarrollo
        /// le pasamos el id del cultivo
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [Route("Umbral")]
        [HttpGet]
        public async Task<IActionResult> CalcularUmbralDesarrollo(string idCultivo)
        {
            return await Task.FromResult(Ok($"Grados acumulados {idCultivo}"));
        }

        [Route("DuracionHuevo")]
        [HttpGet]
        public async Task<IActionResult> CalcularDuracionHuevo(string idCultivo)
        {
            return await Task.FromResult(Ok($"duracion Huevo {idCultivo}"));
        }

        [Route("DuracionPrepupa")]
        [HttpGet]
        public async Task<IActionResult> CalcularPrepupa(string idCultivo)
        {
            return await Task.FromResult(Ok($"duracion prepupa {idCultivo}"));
        }

        [Route("DuracionPupa")]
        [HttpGet]
        public async Task<IActionResult> CalcularPupa(string idCultivo)
        {
            return await Task.FromResult(Ok($"duracion pupa {idCultivo}"));
        }

        [Route("DuracionLarva")]
        [HttpGet]
        public async Task<IActionResult> CalcularLarva(string idCultivo)
        {
            return await Task.FromResult(Ok($"duracion larva {idCultivo}"));
        }

        [Route("DuracionCicloDesarrollo")]
        [HttpGet]
        public async Task<IActionResult> CalcularDuracionCicloDesarrollo(string idCultivo)
        {
            return await Task.FromResult(Ok($"duracion ciclo {idCultivo}"));
        }

        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> ObtenerTemperatura(string idCultivo)
        {
            return await Task.FromResult(Ok($"temperatura {idCultivo}"));
        }

        [Route("Post")]
        [HttpPost]
        public async Task<IActionResult> PostArduino(double temperatura)
        {
            return await Task.FromResult(Ok($"temperatura {temperatura}"));
        }
    }
}
