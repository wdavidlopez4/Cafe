using Cafe.Climate.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public class Monitoring : EntityBase
    {
        public Arduino Arduino { get; private set; }

        public List<ClimaticFactor> Climate { get; private set; }

        public Crop Crop { get; private set; }

        public string CropId { get; private set; }

        internal Monitoring(string cropId, List<ClimaticFactor> climate = null, Guid? id = null) : base(id)
        {
            this.Climate = climate;
            this.CropId = cropId;

            if (Validator.Validate<Monitoring>(this, MonitoringValidation.Validation) == false)
                throw new ArgumentException("modelo es incorrecto");
        }

        private Monitoring()
        {
            //for ef
        }
    }
}
