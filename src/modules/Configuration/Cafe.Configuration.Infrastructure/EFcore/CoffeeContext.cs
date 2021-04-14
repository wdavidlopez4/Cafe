using Cafe.Configuration.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Infrastructure.EFcore
{
    public class CoffeeContext : DbContext
    {
        public DbSet<CoffeeGrower> CoffeeGrowers { get; set; }

        public DbSet<ConfigurationCrop> ConfigurationCrops { get; set; }

        public DbSet<Crop> Crops { get; set; }

        public DbSet<Temperature> Temperatures { get; set; }

        public DbSet<ImageMonitoring> ImageMonitorings { get; set; }

        public DbSet<ManualMonitoring> ManualMonitorings { get; set; }

        
        public CoffeeContext(DbContextOptions options) : base(options)
        {

        }
    }
}
