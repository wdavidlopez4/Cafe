using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Application.TemperatureDegreesDaysServices.CommandDegreesDaysCalculate
{
    public class DegreesDaysCalculateDTO
    {
        public string Id { get; set; }

        public string MonitoringId { get; set; }

        public double DegreesDays { get; set; }

        public DateTime Time { get; set; }
    }
}
