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

        public CoffeeContext(DbContextOptions options) : base(options)
        {

        }
    }
}
