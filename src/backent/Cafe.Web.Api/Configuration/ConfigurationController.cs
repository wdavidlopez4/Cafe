using Cafe.Configuration.Application.MonitoringServices.CommandMonitoringManualBegin;
using Cafe.Configuration.Application.SetUpServices.QuerySetUpByIdCrop;
using Cafe.Web.Api.Filters;
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

namespace Cafe.Web.Api.Configuration
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManagerConfigurationFilter))]
    public class ConfigurationController : ControllerBase
    {
        private readonly IMediator mediator;

        public ConfigurationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("Configuration")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ObtenerConfiguracion([FromBody] SetUpByIdCrop setUpByIdCrop)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            List<Claim> claims = User.Claims.ToList();
            if (claims == null)
                return BadRequest("no se pudieron obtener los claims del token, verifique el token.");

            setUpByIdCrop.Claims = claims;
            var dto = await this.mediator.Send(setUpByIdCrop);

            if (dto == null)
                return BadRequest("no se pudo obtener el cultivo");
            else
                return Ok(dto);
        }

        [HttpGet]
        [Route("ConfigurationCampos")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ObtenerConfiguracion([Bind("CropId")]string cropId)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            List<Claim> claims = User.Claims.ToList();
            if (claims == null)
                return BadRequest("no se pudieron obtener los claims del token, verifique el token.");

            var dto = await this.mediator.Send(new SetUpByIdCrop{ CropId = cropId, Claims = claims});
            if (dto == null)
                return BadRequest("no se pudo obtener el cultivo");
            else
                return Ok(dto);
        }

        [HttpPost]
        [Route("MonitorManual")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ComenzarMonitoreo([FromBody] MonitoringManualBegin monitoringManualBegin)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            List<Claim> claims = User.Claims.ToList();
            if (claims == null)
                return BadRequest("no se pudieron obtener los claims del token, verifique el token.");

            monitoringManualBegin.Claims = claims;
            var dto = await this.mediator.Send(monitoringManualBegin);

            if (dto == null)
                return BadRequest("no se pudo obtener el cultivo");
            else
                return Ok(dto);
        }

        [HttpPost]
        [Route("MonitorInteligente")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ComenzarMonitoreo(string idCultivo, string activarPorImagen)
        {
            return await Task.FromResult(Ok($"comenzar: {idCultivo} {activarPorImagen}"));
        }
    }
}
