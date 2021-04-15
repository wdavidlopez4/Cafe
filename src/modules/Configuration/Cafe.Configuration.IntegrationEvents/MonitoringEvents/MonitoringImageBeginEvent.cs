using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.IntegrationEvents.MonitoringEvents
{
    public class MonitoringImageBeginEvent
    {
        public string Id { get; set; }

        public string ActivateByImage { get; set; }

        public bool Activated { get; set; }

        public string CropId { get; set; }
    }
}
