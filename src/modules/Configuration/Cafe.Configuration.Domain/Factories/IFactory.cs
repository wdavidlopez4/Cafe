using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Factories
{
    public interface IFactory
    {
        public EntityBase CreateCoffeeGrower(string name, string mail, string password, List<Crop> crops = null);
    }
}
