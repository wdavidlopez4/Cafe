using Cafe.Configuration.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Entities
{
    public class ImageMonitoring : Monitoring
    {
        public string ActivateByImage { get; private set; }

        internal ImageMonitoring(string activateByImage, string cropId, Crop crop = null)
            :base(cropId, crop)
        {
            this.ActivateByImage = activateByImage;

            if(Validator.Validate<ImageMonitoring>(this, ImageMonitoringValidation.Validation) == false)
                throw new ArgumentException("la entidad se valido como erronea.");
        }

        private ImageMonitoring():base()
        {
            //for ef
        }
    }
}
