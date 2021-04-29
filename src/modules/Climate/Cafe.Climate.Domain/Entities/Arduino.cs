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

        public string MonitoringId { get; private set; }

        public bool Occupied { get; private set; }

        /// <summary>
        /// contructor de arduino para el ardiuino fisico
        /// </summary>
        /// <param name="temperature"></param>
        /// <param name="humididy"></param>
        /// <param name="altitude"></param>
        internal Arduino(double temperature, double humididy, double altitude)
        {
            this.Altitude = altitude;
            this.Humididy = humididy;
            this.Temperature = temperature;

            if (Validator.Validate<Arduino>(this, ArduinoValidation.Validation) == false)
                throw new ArgumentException("el modelo es invalido");
        }

        internal Arduino(Guid id, string monitoringId, bool occupied):base(id)
        {
            this.MonitoringId = monitoringId;
            this.Occupied = occupied;

            //falta validarlo
        }

        private Arduino()
        {
            //for EF
        }
    }
}
