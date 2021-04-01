using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Entities
{
    public abstract class EntityBase
    {
        public string Id { get; protected set; }

        internal EntityBase(Guid? id = null)
        {
            this.Id = id == null ? Guid.NewGuid().ToString() : id.ToString();
        }

    }
}
