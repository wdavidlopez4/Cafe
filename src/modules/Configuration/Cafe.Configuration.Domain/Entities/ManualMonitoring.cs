using Cafe.Configuration.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Entities
{
    public class ManualMonitoring : Monitoring
    {
        public bool ActivateManually { get; private set; }

        internal ManualMonitoring(bool activateManually, string cropId, Crop crop = null)
            :base(cropId, crop)
        {
            this.ActivateManually = activateManually;
            this.CropId = cropId;
            this.Crop = crop;

            if(Validator.Validate<ManualMonitoring>(this, ManualMonitoringValidation.validation) == false)
                throw new ArgumentException("la entidad se valido como erronea.");
        }

        private ManualMonitoring():base()
        {
            //for EF
        }
    }
}
