using Cafe.Climate.Application.ArduinoEventHandler;
using Cafe.Climate.Application.CropEventHandler;
using Cafe.Configuration.Infrastructure.Startup;
using Cafe.Configuration.IntegrationEvents.ArduinoEvents;
using Cafe.Configuration.IntegrationEvents.CropEvents;
using Cafe.Configuration.IntegrationEvents.MonitoringEvents;
using Cafe.Intelligent.Application.ConfigurationEventHandler.MonitoringEventHandler;
using Cafe.Intelligent.Infrastructure.Startup;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //configuracion api para la autentificacion por jwt token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = Configuration["DOMINIO_APP"],
                     ValidAudience = Configuration["DOMINIO_APP"],
                     IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration["CLAVE_SECRETA"])),
                     ClockSkew = TimeSpan.Zero
                 });

            //subcribirce a los eventos
            services.AddEventBus(builder =>
            {
                builder.AddInMemoryEventBus(subscriber =>
                {
                    //1.el evento, 2.manejador
                    subscriber.Subscribe<MonitoringImageBeginEvent, MonitoringImageEventHandler>();
                    subscriber.Subscribe<ArduinoSyncUpEvent, ArduinoSyncUpEventHandler>();
                    subscriber.Subscribe<CropCreateEvent, CropCreateEventHandler>();
                    //subscriber.SubscribeAllHandledEvents<MyEventHandler>(); // other way
                });
            });

            //iniciar y configurar los modulos
            CoffeeConfigurationStartup.ConfigurationServices(services, this.Configuration);
            CoffeeIntelligentStartup.ConfigurationServices(services, this.Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
