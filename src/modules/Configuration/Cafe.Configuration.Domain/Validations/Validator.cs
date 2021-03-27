using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cafe.Configuration.Domain.Validations
{
    public class Validator
    {
        internal static bool Validate<T>(T obj, params Predicate<T>[] validations) =>
            validations.ToList().Where(x =>
            {
                return !x(obj);
            }).Count() == 0;
    }
}
