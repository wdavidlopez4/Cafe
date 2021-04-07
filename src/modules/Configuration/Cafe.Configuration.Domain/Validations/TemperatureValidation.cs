using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Validations
{
    public class TemperatureValidation
    {
        internal static readonly Predicate<Temperature>[] Validation =
        {
            (x) => x.Id != null && x.Id != "",
            (x) => x.ConfigurationCropId != null && x.ConfigurationCropId != "",
            (x) => x.MaximunThresholdInsectDevelioment > 20 && x.MaximunThresholdInsectDevelioment < 40,
            (x) => x.MinimumThresholdInsectDevelopment > 10 && x.MinimumThresholdInsectDevelopment < 20,
            (x) => x.MinimumEffectiveGrade > 10 && x.MinimumEffectiveGrade < 20,
        };
    }
}
