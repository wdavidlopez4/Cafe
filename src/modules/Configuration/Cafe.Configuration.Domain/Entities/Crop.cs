using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Entities
{
    public class Crop : EntityBase
    {
        public string IdCoffeeGrower { get; private set; }
        
        public CoffeeGrower CoffeeGrower { get; private set; }

        internal Crop(string idCoffeeGrower) : base()
        {
            this.IdCoffeeGrower = idCoffeeGrower;
        }

        private Crop()
        {

        }
    }
}
