using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public class Crop : EntityBase
    {
        public Monitoring Monitoring { get; private set; }

        internal Crop(Guid? id = null):base(id)
        {

        }

        private Crop()
        {
            //for ef
        }
    }
}
