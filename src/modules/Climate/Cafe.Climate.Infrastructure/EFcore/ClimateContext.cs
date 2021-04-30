using Cafe.Climate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Infrastructure.EFcore
{
    public class ClimateContext : DbContext
    {
        public DbSet<Crop> Crops { get; set; }

        public DbSet<Arduino> Arduinos { get; set; }

        public DbSet<ArduinoData> ArduinoDatas { get; set; }

        public DbSet<Monitoring> Monitorings { get; set; }

        public DbSet<TemperatureInceptThreshold> TemperatureInceptThresholds { get; set; }


        public ClimateContext(DbContextOptions<ClimateContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Crop>(entity => {
                entity.ToTable("ClimateCrop");
            });

            builder.Entity<Monitoring>(entity => {
                entity.ToTable("ClimateMonitoring");
            });
        }

    }
}
