using Cafe.Configuration.Infrastructure.EFcore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration; //getConnectionString
using MediatR;
using Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerSignIn;
using Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerLogin;
using System.Reflection;
using Cafe.Configuration.Application.ArduinoServices.CommandArduinoSetUp;
using Cafe.Configuration.Application.ArduinoServices.CommandArduinoSyncUp;
using Cafe.Configuration.Application.CropServices.CommandCropCreate;
using Cafe.Configuration.Application.CropServices.QueryCropById;
using Cafe.Configuration.Application.CropServices.QueryCropByPage;
using Cafe.Configuration.Application.MonitoringServices.CommandMonitoringImageBegin;
using Cafe.Configuration.Application.MonitoringServices.CommandMonitoringManualBegin;
using Cafe.Configuration.Application.SetUpServices.QuerySetUpByIdCrop;
using Cafe.Configuration.Application.TemperatureServices.CommandTemperatureSetUp;

namespace Cafe.Configuration.Infrastructure.Startup
{
    public static class CoffeeConfigurationStartup
    {
        public static void ConfigurationServices(IServiceCollection services, IConfiguration configuration)
        {
            InyectionContainer.Inyection(services);
            ConfigurationSqlServer(services, configuration);
            ConfigurarMapper(services);
            ConfigurarMediador(services);

            
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
            services.AddMediatR(typeof(ArduinoSetUp).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ArduinoSyncUp).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CoffeGrowerLogin).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CoffeeGrowerSignIn).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CropCreate).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CropById).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CropByPage).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(MonitoringImageBegin).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(MonitoringManualBegin).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(SetUpByIdCrop).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(TemperatureSetUp).GetTypeInfo().Assembly);
        }
    }
}
