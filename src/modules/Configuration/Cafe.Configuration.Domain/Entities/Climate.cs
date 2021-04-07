using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cafe.Configuration.Domain.Entities
{
    public abstract class Climate : EntityBase
    {
        public string ConfigurationCropId { get; private set; }

        public ConfigurationCrop ConfigurationCrop { get; private set; }

        protected Climate(string configurationCropId, ConfigurationCrop configurationCrop = null)
        {
            this.ConfigurationCropId = configurationCropId;
            this.ConfigurationCrop = configurationCrop;
        }

        protected Climate()
        {
            //for Ef
        }
    }
}
