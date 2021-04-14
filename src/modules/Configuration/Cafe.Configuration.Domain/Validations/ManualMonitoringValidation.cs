using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Validations
{
    public class ManualMonitoringValidation
    {
        internal static readonly Predicate<ManualMonitoring>[] validation =
        {
            (x) => x.Id != null && x.Id != "",
            (x) => x.CropId != null && x.CropId != ""
        };
    }
}
