using Cafe.Climate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Validations
{
    public class ArduinoDataValidation
    {
        internal static readonly Predicate<ArduinoData>[] Validation =
        {
            (x) => x.Id != null && x.Id != "",
            (x) => x.Altitude >= 0,
            (x) => x.Humididy >= 0,
            (x) => x.Temperature >= 0
        };
    }
}
