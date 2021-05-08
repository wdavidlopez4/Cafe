using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public class TemperatureDegreesDays : ClimaticFactor
    {
        public double DegreesDays { get; private set; } 

        public DateTime Time { get; private set; }

        internal TemperatureDegreesDays(string monitoringId, double DegreesDays, DateTime Time):base(monitoringId)
        {
            this.DegreesDays = DegreesDays;
            this.Time = Time;

            //Falta Validar
        }

        private TemperatureDegreesDays():base()
        {
            //For EF
        }
    }
}
