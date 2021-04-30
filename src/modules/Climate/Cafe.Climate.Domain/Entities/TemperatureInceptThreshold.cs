using Cafe.Climate.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public class TemperatureInceptThreshold : ClimaticFactor
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
        public double MaximunDevelopmentThreshold { get; private set; }

        /// <summary>
        /// umbral maximo detectado de temperatura
        /// </summary>
        public double MinimunDevelopmentThreshold { get; private set; }

        internal TemperatureInceptThreshold(string monitoringId, string averageWeatherId, string optimalStateDevelopmentThreshold,
            double optimalTemperatureDevelopmentThreshold, double UmD, double UMD, Guid? id = null): base(monitoringId, /*averageWeatherId,*/ id)
        {
            this.OptimalStateDevelopmentThreshold = optimalStateDevelopmentThreshold;
            this.OptimalTemperatureDevelopmentThreshold = optimalTemperatureDevelopmentThreshold;
            this.MaximunDevelopmentThreshold = UmD;
            this.MinimunDevelopmentThreshold = UMD;

            if (Validator.Validate<TemperatureInceptThreshold>(this, TemperatureInceptThresholdValidation.Validation) == false)
                throw new ArgumentException("modelo incorrecto");
        }

        private TemperatureInceptThreshold():base()
        {
            //for ef
        }
    }
}
