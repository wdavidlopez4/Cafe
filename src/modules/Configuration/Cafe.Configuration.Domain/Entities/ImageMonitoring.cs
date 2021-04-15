using Cafe.Configuration.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Entities
{
    public class ImageMonitoring : Monitoring
    {
        public string ActivateByImage { get; private set; }

        public bool Activated { get; private set; }

        internal ImageMonitoring(string activateByImage, bool activated, string cropId, Crop crop = null)
            :base(cropId, crop)
        {
            this.ActivateByImage = activateByImage;
            this.Activated = activated;
            this.CropId = cropId;

            if(Validator.Validate<ImageMonitoring>(this, ImageMonitoringValidation.Validation) == false)
                throw new ArgumentException("la entidad se valido como erronea.");
        }

        private ImageMonitoring():base()
        {
            //for ef
        }
    }
}
