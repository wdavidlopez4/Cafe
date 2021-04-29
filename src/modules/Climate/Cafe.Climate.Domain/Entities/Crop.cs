using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public class Crop : EntityBase
    {
        public Monitoring Monitoring { get; private set; }

        public string Name { get; private set; }

        public string CoffeeGrowerId { get; private set; }

        internal Crop(Guid id, string name, string coffeeGrowerId) :base(id)
        {
            this.Name = name;
            this.CoffeeGrowerId = coffeeGrowerId;
        }

        private Crop()
        {
            //for ef
        }
    }
}
