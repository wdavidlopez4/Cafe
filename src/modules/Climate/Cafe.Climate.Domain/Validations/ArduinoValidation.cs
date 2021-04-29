using Cafe.Climate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Validations
{
    public class ArduinoValidation
    {
        internal static readonly Predicate<Arduino>[] Validation =
        {
            (x) => x.Id != null && x.Id != "",
            (x) => x.Altitude >= 0,
            (x) => x.Humididy >= 0,
            (x) => x.Temperature >= 0
        };
    }
}
