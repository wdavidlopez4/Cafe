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

            (c)=> c.Nombre != null && c.Nombre != "",

            (c)=> c.DiasFormacion >= 0,

            (c)=> c.CoffeeGrowerId != null && c.CoffeeGrowerId != ""

        };
    }
}
