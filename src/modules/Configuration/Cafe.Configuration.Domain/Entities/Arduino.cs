using Cafe.Configuration.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Entities
{
    public class Arduino : EntityBase
    {
        public string Name { get; private set; }

        public string ConfigurationCropId { get; private set; }

        public bool Occupied { get; private set; }

        public ConfigurationCrop ConfigurationCrop { get; private set; }

        internal Arduino(string name, string configurationCropId, ConfigurationCrop configurationCrop = null)
        {
            this.Name = name;
            this.ConfigurationCropId = configurationCropId;
            this.ConfigurationCrop = configurationCrop;
            this.Occupied = false;

            if (Validator.Validate<Arduino>(this, ArduinoValidation.Validation) == false)
                throw new ArgumentException("la entidad se valido como erronea.");
        }

        private Arduino()
        {
            //for ef
        }
    }
}
