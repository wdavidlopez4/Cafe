using Cafe.Climate.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public class ArduinoData : EntityBase
    {
        public double Temperature { get; private set; }

        public double Humididy { get; private set; }

        public double Altitude { get; private set; }

        public DateTime Time { get; private set; }

        public Arduino Arduino { get; private set; }

        public string ArduinoId { get; private set; }

        internal ArduinoData(double temperature, double humididy, double altitude, DateTime time, string ArduinoId)
        {
            this.Altitude = altitude;
            this.Humididy = humididy;
            this.Temperature = temperature;
            this.Time = time;
            this.ArduinoId = ArduinoId;

            if (Validator.Validate<ArduinoData>(this, ArduinoDataValidation.Validation) == false)
                throw new ArgumentException("el modelo es invalido");
        }

        private ArduinoData()
        {
            //for ef
        }
    }
}
