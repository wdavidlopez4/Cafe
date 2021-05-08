using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public abstract class ClimaticFactor : EntityBase
    {
        public Monitoring Monitoring { get; private set; }

        public string MonitoringId { get; private set; }

        internal protected ClimaticFactor(string monitoringId, Guid? id = null): base(id)
        {
            this.MonitoringId = monitoringId;
        }

        internal protected ClimaticFactor(Guid? id = null) : base(id)
        {
            //for ef
        }
    }
}
