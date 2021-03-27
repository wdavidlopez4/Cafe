using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Configuration.Domain.Validations;

namespace Cafe.Configuration.Domain.Factories
{
    public class Factory : IFactory
    {
        public EntityBase CreateCoffeeGrower(string name, string mail, string password, List<Crop> crops = null)
        {
            return new CoffeeGrower(name, mail, password, crops);
        }
    }
}
