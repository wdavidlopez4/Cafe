using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Entities
{
    public abstract class EntityBase
    {
        public string Id { get; private set; }

        internal EntityBase()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
