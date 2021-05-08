using Cafe.Climate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Application.TemperatureInceptThresholdServices.CommandInceptThresholdCalculate
{
    public class InceptThresholdCalculateDTO
    {
        public string Id { get; set; }

        public string MonitoringId { get; set; }

        /// <summary>
        /// estado del umbral optimo de desarrollo en temperatura promedia
        /// </summary>
        public OptimalDevelopmentThresholdEnum OptimalStateDevelopmentThreshold { get; set; }

        /// <summary>
        /// temperatura del umbral optimo de desarrollo en temperatura promedia
        /// </summary>
        public double OptimalTemperatureDevelopmentThreshold { get; set; }

    }
}
