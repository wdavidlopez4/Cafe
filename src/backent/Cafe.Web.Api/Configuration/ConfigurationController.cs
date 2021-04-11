using Cafe.Web.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> ObtenerConfiguracion(string idCultivo)
        {
            return Ok(await Task.FromResult(""));
        }
    }
}
