using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public abstract class EntityBase
    {
        public string Id { get; internal protected set; }

        internal protected EntityBase(Guid? id = null)
        {
            this.Id = id == null ? Guid.NewGuid().ToString() : id.ToString();
        }
    }
}
