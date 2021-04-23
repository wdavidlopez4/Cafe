using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Intelligent.Infrastructure.Startup
{
    public class CoffeeIntelligentStartup
    {
        public static void ConfigurationServices(IServiceCollection services, IConfiguration configuration)
        {
            InyectionContainer.Inyection(services);
            ConfigurationBlobStorage(services, configuration);
        }

        private static void ConfigurationBlobStorage(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection(key: "AzureBlobStorageConnectionString").Value;
            services.AddSingleton(x => new BlobServiceClient(connectionString: connectionString));
        }
    }
}
