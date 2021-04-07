using Cafe.Configuration.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Entities
{
    public class Temperature : Climate
    {
        public double MinimumThresholdInsectDevelopment { get; private set; }

        public double MaximunThresholdInsectDevelioment { get; private set; }

        public double MinimumEffectiveGrade { get; private set; }

        internal Temperature(string ConfigurationCropId, double MinimumThresholdInsectDevelopment, double MaximunThresholdInsectDevelioment, 
            double MinimumEffectiveGrade, ConfigurationCrop configurationCrop = null) : base(ConfigurationCropId, configurationCrop)
        {
            this.MaximunThresholdInsectDevelioment = MaximunThresholdInsectDevelioment;
            this.MinimumThresholdInsectDevelopment = MinimumThresholdInsectDevelopment;
            this.MinimumEffectiveGrade = MinimumEffectiveGrade;

            if (Validator.Validate<Temperature>(this, TemperatureValidation.Validation) == false)
                throw new ArgumentException("la entidad se valido como erronea.");
        }

        private Temperature(): base ()
        {
            //for ef
        }
    }
}
