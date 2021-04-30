using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration; //getConnectionString
using Cafe.Climate.Infrastructure.EFcore;
using Cafe.Climate.Application.ArduinoServices.CommandArduinoSetData;
using Cafe.Climate.Application.ArduinoServices.QueryArduinoByRangeTime;
using System.Reflection;

namespace Cafe.Climate.Infrastructure.Startup
{
    public static class CoffeeClimateStartup
    {
        public static void ConfigurationServices(IServiceCollection services, IConfiguration configuration)
        {
            InyectionContainer.Inyection(services);
            ConfigurationSqlServer(services, configuration);
            ConfigurarMapper(services);
            ConfigurarMediador(services);

            
        }

        private static void ConfigurationSqlServer(IServiceCollection services, IConfiguration configuration)
        {
            // entity framework db context
            string connString = configuration.GetConnectionString("CafeConnectionString"); //obtenemos la cadena de coneccion DESDE EL ARCHIVO APPSETTINGS
            services.AddDbContext<ClimateContext>(
                options => options.UseSqlServer(connString));
        }

        private static void ConfigurarMapper(IServiceCollection services)
        {
            //mapeo de entidades
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        private static void ConfigurarMediador(IServiceCollection services)
        {
            services.AddMediatR(typeof(ArduinoDataSet).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ArduinoByRangeTime).GetTypeInfo().Assembly);
        }
    }
}
