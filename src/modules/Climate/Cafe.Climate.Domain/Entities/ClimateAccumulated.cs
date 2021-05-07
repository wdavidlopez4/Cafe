using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public class ClimateAccumulated : EntityBase
    {
        public double AccumulatedTemperature { get; private set; }

        public double AccumulatedHumedity { get; private set; }

        public double AccumulatedAltitude { get; private set; }

        public Monitoring Monitoring { get; private set; }

        public string MonitoringId { get; private set; }

        /// <summary>
        /// contador de los datos
        /// </summary>
        public string ContData { get; private set; }

        internal ClimateAccumulated(double accumulatedTemperature, double accumulatedHumedity, 
            double accumulatedAltitude, string monitoringId):base()
        {
            this.AccumulatedTemperature = accumulatedTemperature;
            this.AccumulatedHumedity = accumulatedHumedity;
            this.AccumulatedAltitude = accumulatedAltitude;

            this.MonitoringId = monitoringId;

            //falta validar
        }

        private ClimateAccumulated()
        {
            //for EF
        }
    }
}
