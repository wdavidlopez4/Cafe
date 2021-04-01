using Cafe.Configuration.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Entities
{
    public class Crop : EntityBase
    {
        public string Nombre { get; private set; }

        public int DiasFormacion { get; private set; }

        public string ConfigurationCropId { get; private set; }

        public string CoffeeGrowerId { get; private set; }
        
        public CoffeeGrower CoffeeGrower { get; private set; }

        public ConfigurationCrop ConfigurationCrop { get; private set; }

        internal Crop(string nombre, int diasFormacion, string coffeeGrowerId, string configurationCropId = null) : base()
        {
            this.Nombre = nombre;
            this.DiasFormacion = diasFormacion;
            this.CoffeeGrowerId = coffeeGrowerId;
            this.ConfigurationCropId = configurationCropId;

            if (Validator.Validate<Crop>(this, CropValidation.Validation) == false)
                throw new ArgumentException("la entidad se valido como erronea.");
        }

        private Crop()
        {

        }
    }
}
