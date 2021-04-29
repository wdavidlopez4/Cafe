using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public class Crop : EntityBase
    {
        public Monitoring Monitoring { get; private set; }

        public string Name { get; private set; }

        internal Crop(Guid id, string name):base(id)
        {
            this.Name = name;
        }

        private Crop()
        {
            //for ef
        }
    }
}
