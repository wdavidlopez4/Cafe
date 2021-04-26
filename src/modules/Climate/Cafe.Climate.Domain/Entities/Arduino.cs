using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public class Arduino
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
        }

        private Arduino()
        {
            //for EF
        }
    }
}
