using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.IntegrationEvents.ArduinoEvents
{
    public class ArduinoSyncUpEvent
    {
        public string Id { get; set; }

        public string CropId { get; set; }

        public string Name { get; set; }

        public bool Occupied { get; set; }
    }
}
