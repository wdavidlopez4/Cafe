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
        public OptimalDevelopmentThresholdEnum OptimalStateDevelopmentThreshold { get; private set; }

        /// <summary>
        /// temperatura del umbral optimo de desarrollo en temperatura promedia
        /// </summary>
        public double OptimalTemperatureDevelopmentThreshold { get; private set; }

        internal TemperatureInceptThreshold(string monitoringId, OptimalDevelopmentThresholdEnum optimalStateDevelopmentThreshold,
            double optimalTemperatureDevelopmentThreshold, Guid? id = null): base(monitoringId, id)
        {
            this.OptimalStateDevelopmentThreshold = optimalStateDevelopmentThreshold;
            this.OptimalTemperatureDevelopmentThreshold = optimalTemperatureDevelopmentThreshold;

            if (Validator.Validate<TemperatureInceptThreshold>(this, TemperatureInceptThresholdValidation.Validation) == false)
                throw new ArgumentException("modelo incorrecto");
        }

        private TemperatureInceptThreshold():base()
        {
            //for ef
        }
    }
}
