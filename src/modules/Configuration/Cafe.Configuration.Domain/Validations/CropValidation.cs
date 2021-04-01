using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Validations
{
    public class CropValidation
    {
        internal static readonly Predicate<Crop>[] Validation =
        {
            (c)=> c.Id != null && c.Id != "",

            (c)=> c.Name != null && c.Name != "",

            (c)=> c.DayFormation >= 0,

            (c)=> c.CoffeeGrowerId != null && c.CoffeeGrowerId != ""

        };
    }
}
