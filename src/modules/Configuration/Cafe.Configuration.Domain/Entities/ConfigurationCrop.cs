using Cafe.Configuration.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Validator = Cafe.Configuration.Domain.Validations.Validator;

namespace Cafe.Configuration.Domain.Entities
{
    public class ConfigurationCrop : EntityBase
    {
        [Key, ForeignKey("Crop")]
        public string CropId { get; private set; }

        public Crop Crop { get; private set; }

        public Temperature Temperature { get; private set; }

        internal ConfigurationCrop(string cropId, Temperature temperature = null)
        {
            this.CropId = cropId;
            this.Temperature = temperature;

            if (Validator.Validate<ConfigurationCrop>(this, ConfigurationCropValidation.Validation) == false)
                throw new ArgumentException("la entidad se valido como erronea.");
        }

        private ConfigurationCrop()
        {
            //for ef
        }
    }
}
