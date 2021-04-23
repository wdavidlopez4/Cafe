﻿using Cafe.Intelligent.Domain.Factories;
using Cafe.Intelligent.Domain.Ports;
using Cafe.Intelligent.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Intelligent.Infrastructure.Startup
{
    public class InyectionContainer
    {
        public static void Inyection(IServiceCollection services)
        {
            services.AddScoped<IFactory, Factory>();
            services.AddScoped<IRepositoryBlob, RepositoryBlob>();
            services.AddScoped<IDirectoryProgram, DirectoryProgram>();
            //services.AddScoped<FitML>();
        }
    }

}