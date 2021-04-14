﻿using Cafe.Configuration.Application.CropServices.CommandCropCreate;
using Cafe.Configuration.Application.CropServices.QueryCropById;
using Cafe.Configuration.Application.CropServices.QueryCropByPage;
using Cafe.Configuration.Application.TemperatureServices.CommandTemperatureSetUp;
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
using System.Web.Providers.Entities;

namespace Cafe.Web.Api.Configuration
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManagerConfigurationFilter))]
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

        /// <summary>
        /// es una altrnativa al obtener el cultivo con json
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("cultivoCampos")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ObtenerCultivo([Bind("id")] string id)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            List<Claim> claims = User.Claims.ToList();
            if (claims == null)
                return BadRequest("no se pudieron obtener los claims del token, verifique el token.");

            var dto = await this.mediator.Send(new CropById { Id = id, Claims = claims});

            if (dto == null)
                return BadRequest("no se pudo obtener el cultivo");
            else
                return Ok(dto);
        }

        [HttpGet]
        [Route("cultivos")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ObtenerCultivos([FromBody] CropByPage cropByPage)
        {
            if (cropByPage == null)
                return BadRequest("el modelo es incorrecto.");

            cropByPage.Claims = User.Claims.ToList();

            var dto = await this.mediator.Send(cropByPage);
            if (dto == null)
                return BadRequest("la restuesta para obtener el culto fue nula");
            else
                return Ok(dto);

        }

        /// <summary>
        /// api alternativa de cultivos, en ves de enviar json envia los campos
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("cultivosCampos")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ObtenerCultivos([Bind("pageNumber,pageSize")]int pageNumber, int pageSize)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            List<Claim> claims = User.Claims.ToList();
            if (claims == null)
                return BadRequest("no se pudieron obtener los claims del token, verifique el token.");

            var dto = await this.mediator.Send(new CropByPage { 
                PageNumber = pageNumber, 
                PageSize = pageSize, 
                Claims = claims });

            if (dto == null)
                return BadRequest("no se pudo obtener el cultivo");
            else
                return Ok(dto);
        }

        [HttpPost]
        [Route("Temperatura")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ConfigurarTemperatura([FromBody] TemperatureSetUp temperatureSetUp)
        {
            if (temperatureSetUp == null)
                return BadRequest("el modelo es incorrecto.");

            temperatureSetUp.Claims = User.Claims.ToList();

            var dto = await this.mediator.Send(temperatureSetUp);
            if (dto == null)
                return BadRequest("la restuesta para obtener la temperatura fue nula");
            else
                return Ok(dto);
        }

    }
}
