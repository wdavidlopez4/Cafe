using Cafe.Configuration.Domain.Factories;
using Cafe.Configuration.Domain.Ports;
using Cafe.Configuration.Infrastructure.Mapping;
using Cafe.Configuration.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Infrastructure.Startup
{
    public class InyectionContainer
    {
        public static void Inyection(IServiceCollection services)
        {
            services.AddScoped<IRepository, RepositorySQL>();
            services.AddScoped<IAutoMapping, AutoMapping>();
            services.AddScoped<IFactory, Factory>();
        }
    }
}
