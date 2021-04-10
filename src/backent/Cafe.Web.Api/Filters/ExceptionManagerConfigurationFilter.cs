using Cafe.Configuration.Application.Exceptions;
using Cafe.Configuration.Infrastructure.Exceptions;
using Cafe.Configuration.Infrastructure.Mapping;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe.Web.Api.Filters
{
    public class ExceptionManagerConfigurationFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ExceptionManagerConfigurationFilter(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            if(context.Exception is DuplicityEntityException)
            {
                context.Result = new JsonResult($"error de duplicidad de entidad en: {this.webHostEnvironment.ApplicationName} " +
                    $"tipo exepcion: {context.Exception.GetType()} exepcion: {context.Exception.Message}");
            }
            else if(context.Exception is TokenException)
            {
                context.Result = new JsonResult($"error de seguridad del token en: {this.webHostEnvironment.ApplicationName} " +
                    $"tipo exepcion: {context.Exception.GetType()} exepcion: {context.Exception.Message}");
            }
            else if (context.Exception is EncriptException)
            {
                context.Result = new JsonResult($"error de seguridad de la encriptacion en: {this.webHostEnvironment.ApplicationName} " +
                    $"tipo exepcion: {context.Exception.GetType()} exepcion: {context.Exception.Message}");
            }
            else if(context.Exception is ArgumentNullException)
            {
                context.Result = new JsonResult($"error de argumento: {this.webHostEnvironment.ApplicationName} " +
                    $"tipo exepcion: {context.Exception.GetType()} exepcion: {context.Exception.Message}");
            }
            else if(context.Exception is ArgumentDifferentException)
            {
                context.Result = new JsonResult($"argumentos diferente: {this.webHostEnvironment.ApplicationName} " +
                    $"tipo exepcion: {context.Exception.GetType()} exepcion: {context.Exception.Message}");
            }
            else if(context.Exception is EntityNullException)
            {
                context.Result = new JsonResult($"error de entidad: {this.webHostEnvironment.ApplicationName} " +
                    $"tipo exepcion: {context.Exception.GetType()} exepcion: {context.Exception.Message}");
            }
            else if(context.Exception is AutoMappingException)
            {
                context.Result = new JsonResult($"mapeo de entidad erronea: {this.webHostEnvironment.ApplicationName} " +
                    $"tipo exepcion: {context.Exception.GetType()} exepcion: {context.Exception.Message}");
            }
            else if(context.Exception is DbSQLException)
            {
                context.Result = new JsonResult($"error en la base de datos: {this.webHostEnvironment.ApplicationName} " +
                    $"tipo exepcion: {context.Exception.GetType()} exepcion: {context.Exception.Message}");
            }
            else if(context.Exception is ArgumentException)
            {
                context.Result = new JsonResult($"parametos no validos: {this.webHostEnvironment.ApplicationName} " +
                    $"tipo exepcion: {context.Exception.GetType()} exepcion: {context.Exception.Message}");
            }
        }
    }
}
