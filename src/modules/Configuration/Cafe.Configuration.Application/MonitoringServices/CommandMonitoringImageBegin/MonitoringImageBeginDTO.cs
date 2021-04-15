using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.MonitoringServices.CommandMonitoringImageBegin
{
    public class MonitoringImageBeginDTO
    {
        public string Id { get; set; }

        public string CropId { get; set; }

        public string ActivateByImage { get; set; }

        public bool Activated { get; set; }
    }
}
