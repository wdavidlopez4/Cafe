using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    /// <summary>
    /// representa el clima promedio
    /// </summary>
    public class AverageWeather : EntityBase
    {
        public double AccumulatedTemperatureWeek { get; private set; }

        public double AccumulatedTemperatureMonth { get; private set; }

        public double AccumulatedTemperatureHour { get; private set; }

        public double AccumulatedTemperatureMinute { get; private set; }

        public ClimaticFactor Climate { get; private set; }

        internal AverageWeather(double accumulatedTemperatureWeek, double accumulatedTemperatureMonth,
            double accumulatedTemperatureHour, double accumulatedTemperatureMinute)
        {
            this.AccumulatedTemperatureHour = accumulatedTemperatureHour;
            this.AccumulatedTemperatureMonth = accumulatedTemperatureMonth;
            this.AccumulatedTemperatureWeek = accumulatedTemperatureWeek;
            this.AccumulatedTemperatureMinute = accumulatedTemperatureMinute;
        }

        private AverageWeather()
        {
            //for ef
        }
    }
}
