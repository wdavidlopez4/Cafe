using Cafe.Climate.Application.TemperatureDegreesDaysServices.CommandDegreesDaysCalculate;
using Cafe.Climate.Application.TemperatureInceptThresholdServices.CommandInceptThresholdCalculate;
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
    public class TemperaturaController : ControllerBase
    {

        private readonly IMediator mediator;

        public TemperaturaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

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
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CalcularGradosDia(DegreesDaysCalculate degreesDaysCalculate)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            List<Claim> claims = User.Claims.ToList();
            if (claims == null)
                return BadRequest("no se pudieron obtener los claims del token, verifique el token.");

            degreesDaysCalculate.Claims = claims;
            var dto = await this.mediator.Send(degreesDaysCalculate);

            if (dto == null)
                return BadRequest("no se pudo crear el cultivo.");
            else
                return Ok(dto);
        }

        /// <summary>
        /// calcula el minimo y maximo umbral de desarrollo
        /// le pasamos el id del cultivo
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [Route("Umbral")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CalcularUmbralDesarrollo(InceptThresholdCalculate inceptThresholdCalculate)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            List<Claim> claims = User.Claims.ToList();
            if (claims == null)
                return BadRequest("no se pudieron obtener los claims del token, verifique el token.");

            inceptThresholdCalculate.Claims = claims;
            var dto = await this.mediator.Send(inceptThresholdCalculate);

            if (dto == null)
                return BadRequest("no se pudo crear el cultivo.");
            else
                return Ok(dto);
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
