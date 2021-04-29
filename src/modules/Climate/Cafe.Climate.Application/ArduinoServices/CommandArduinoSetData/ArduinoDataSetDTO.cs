using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Application.ArduinoServices.CommandArduinoSetData
{
    public class ArduinoDataSetDTO
    {
        public string Id { get; set; }

        public double Temperature { get; set; }

        public double Humididy { get; set; }

        public double Altitude { get; set; }

        public DateTime Time { get; set; }
    }
}
