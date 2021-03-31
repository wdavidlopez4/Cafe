using Cafe.Configuration.Infrastructure.EFcore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration; //getConnectionString
using MediatR;
using Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerCreate;

namespace Cafe.Configuration.Infrastructure.Startup
{
    public static class CoffeeStartup
    {
        public static void ConfigurationServices(IServiceCollection services, IConfiguration configuration)
        {
            ConfigurationSqlServer(services, configuration);
            ConfigurarMapper(services);
            ConfigurarMediador(services);

            InyectionContainer.Inyection(services);
        }

        /// <summary>
        /// configura el sql server
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private static void ConfigurationSqlServer(IServiceCollection services, IConfiguration configuration)
        {
            // entity framework db context
            string connString = configuration.GetConnectionString("CafeConnectionString"); //obtenemos la cadena de coneccion DESDE EL ARCHIVO APPSETTINGS
            services.AddDbContext<CoffeeContext>(
                options => options.UseSqlServer(connString));
        }

        /// <summary>
        /// configura el mapeo del sistema dto-entitdades de modelo
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigurarMapper(IServiceCollection services)
        {
            //mapeo de entidades
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        /// <summary>
        /// configura el patron mediator controladores- servicios
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigurarMediador(IServiceCollection services)
        {
            services.AddMediatR(typeof(CoffeeGrowerCreate).Assembly);
        }
    }
}
