using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public class TemperatureInceptThreshold : Climate
    {
        /// <summary>
        /// estado del umbral optimo de desarrollo en temperatura promedia
        /// </summary>
        public string OptimalStateDevelopmentThreshold { get; private set; }

        /// <summary>
        /// temperatura del umbral optimo de desarrollo en temperatura promedia
        /// </summary>
        public double OptimalTemperatureDevelopmentThreshold { get; private set; }

        /// <summary>
        /// umbral minimo detectado de temperatura
        /// </summary>
        public double UmD { get; private set; }

        /// <summary>
        /// umbral maximo detectado de temperatura
        /// </summary>
        public double UMD { get; private set; }

        internal TemperatureInceptThreshold(string monitoringId, string averageWeatherId, string optimalStateDevelopmentThreshold,
            double optimalTemperatureDevelopmentThreshold, double UmD, double UMD, Guid? id): base(monitoringId, averageWeatherId, id)
        {
            this.OptimalStateDevelopmentThreshold = optimalStateDevelopmentThreshold;
            this.OptimalTemperatureDevelopmentThreshold = optimalTemperatureDevelopmentThreshold;
            this.UmD = UmD;
            this.UMD = UMD;
        }

        private TemperatureInceptThreshold():base()
        {
            //for ef
        }
    }
}
