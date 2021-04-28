using Cafe.Climate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Validations
{
    public class TemperatureInceptThresholdValidation
    {
        internal static readonly Predicate<TemperatureInceptThreshold>[] Validation =
        {
            (x) => x.Id != null && x.Id != "",
            (x) => x.OptimalStateDevelopmentThreshold != null && x.OptimalStateDevelopmentThreshold != "",
        };
    }
}
