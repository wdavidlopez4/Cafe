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

        public string ClimateId { get; private set; }

        public List<Climate> Climates { get; private set; }

        internal ConfigurationCrop(string cropId, List<Climate> climates = null)
        {
            this.CropId = cropId;
            this.Climates = climates;

            if (Validator.Validate<ConfigurationCrop>(this, ConfigurationCropValidation.Validation) == false)
                throw new ArgumentException("la entidad se valido como erronea.");
        }

        private ConfigurationCrop()
        {
            //for ef
        }
    }
}
