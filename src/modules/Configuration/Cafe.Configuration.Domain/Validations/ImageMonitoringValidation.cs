using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Validations
{
    public class ImageMonitoringValidation
    {
        internal static readonly Predicate<ImageMonitoring>[] Validation =
        {
            //si el id es vacio o nulo
            (c) => c.Id != null && c.Id != "",

            //si el nombre es vacio o nulo
            (c) => c.CropId != null && c.CropId != "",

            //si el nombre es vacio o nulo
            (c) => c.ActivateByImage != null && c.ActivateByImage != ""
        };
    }
}
