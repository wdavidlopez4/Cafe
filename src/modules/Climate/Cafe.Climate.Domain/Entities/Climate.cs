using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public abstract class Climate : EntityBase
    {
        public Monitoring Monitoring { get; private set; }

        public string MonitoringId { get; private set; }

        public AverageWeather AverageWeather { get; private set; }

        public string AverageWeatherId { get; private set; }

        internal protected Climate(string monitoringId, string averageWeatherId, Guid? id = null): base(id)
        {
            this.MonitoringId = monitoringId;
            this.AverageWeatherId = averageWeatherId;
        }

        internal protected Climate(Guid? id = null) : base(id)
        {
            //for ef
        }
    }
}
