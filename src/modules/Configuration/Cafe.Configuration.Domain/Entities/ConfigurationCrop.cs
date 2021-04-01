using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cafe.Configuration.Domain.Entities
{
    public class ConfigurationCrop
    {
        [Key, ForeignKey("Conductor")]
        public string CropId { get; private set; }

        public Crop Crop { get; private set; }

        internal ConfigurationCrop(string cropId)
        {
            this.CropId = cropId;
        }

        private ConfigurationCrop()
        {

        }
    }
}
