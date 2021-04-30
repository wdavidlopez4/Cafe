using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Application.ArduinoServices.QueryArduinoByRangeTime
{
    public class ArduinoByRangeTimeDTO
    {
        public double Temperature { get; set; }

        public double Humididy { get; set; }

        public double Altitude { get; set; }

        public DateTime Time { get; set; }

        public string ArduinoId { get; set; }
    }
}
