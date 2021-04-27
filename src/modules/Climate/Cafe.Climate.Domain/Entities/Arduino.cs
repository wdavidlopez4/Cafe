using Cafe.Climate.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public class Arduino : EntityBase
    {
        public double Temperature { get; private set; }

        public double Humididy { get; private set; }

        public double Altitude { get; private set; }

        public Monitoring Monitoring { get; private set; }

        internal Arduino(double temperature, double humididy, double altitude, Monitoring monitoring = null)
        {
            this.Altitude = altitude;
            this.Humididy = humididy;
            this.Temperature = temperature;
            this.Monitoring = monitoring;

            if (Validator.Validate<Arduino>(this, ArduinoValidation.Validation) == false)
                throw new ArgumentException("el modelo es invalido");
        }

        private Arduino()
        {
            //for EF
        }
    }
}
