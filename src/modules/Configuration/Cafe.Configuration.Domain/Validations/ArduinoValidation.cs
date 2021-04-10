using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Validations
{
    public class ArduinoValidation
    {
        internal static readonly Predicate<Arduino>[] Validation =
        {
            //si el id es vacio o nulo
            (c) => c.Id != null && c.Id != "",

            //si el nombre es vacio o nulo
            (c) => c.Name != null && c.Name != "",

            //si el nombre es vacio o nulo
            (c) => c.ConfigurationCropId != null && c.ConfigurationCropId != "",
        };
    }
}
