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


        public ClimateContext(DbContextOptions options) : base(options)
        {

        }
    }
}
