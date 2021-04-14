using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Entities
{
    public abstract class Monitoring : EntityBase
    {
        public Crop Crop { get; protected set; }

        public string CropId { get; protected set; }

        protected Monitoring(string cropId, Crop crop = null)
        {
            this.Crop = crop;
            this.CropId = cropId;
        }

        protected Monitoring()
        {
            //for ef
        }
    }
}
