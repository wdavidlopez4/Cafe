using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.MonitoringServices.CommandMonitoringManualBegin
{
    public class MonitoringManualBeginDTO
    {
        public string Id { get; set; }

        public string CropId { get; set; }

        public bool ActivateManually { get; set; }
    }
}
