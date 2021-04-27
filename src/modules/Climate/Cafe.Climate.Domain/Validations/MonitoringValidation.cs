using Cafe.Climate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Validations
{
    public class MonitoringValidation
    {
        internal static readonly Predicate<Monitoring>[] Validation =
        {
            (x) => x.Id != null && x.Id != "",
            (x) => x.ArduinoId != null && x.ArduinoId != "",
        };
    }
}
