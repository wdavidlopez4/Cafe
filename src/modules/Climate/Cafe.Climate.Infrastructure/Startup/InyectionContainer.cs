using Cafe.Climate.Domain.Factories;
using Cafe.Climate.Domain.Ports;
using Cafe.Climate.Infrastructure.Mapping;
using Cafe.Climate.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Infrastructure.Startup
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
