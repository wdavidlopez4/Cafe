using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.ArduinoServices.CommandArduinoSetUp
{
    public class ArduinoSetUpDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ConfigurationCropId { get; set; }

        public bool Occupied { get; set; }

        public ConfigurationCrop ConfigurationCrop { get; }
    }
}
