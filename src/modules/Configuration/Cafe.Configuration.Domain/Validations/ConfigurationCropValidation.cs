using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Validations
{
    public class ConfigurationCropValidation
    {
        internal static readonly Predicate<ConfigurationCrop>[] Validation =
        {
            (x) => x.Id != null && x.Id != "",
            (x) => x.CropId != null && x.CropId != "",
        };
    }
}
