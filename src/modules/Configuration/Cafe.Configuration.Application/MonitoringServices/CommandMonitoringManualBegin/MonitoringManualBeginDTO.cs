using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.MonitoringServices.CommandMonitoringManualBegin
{
    public class MonitoringManualBeginDTO
    {
        public string Id { get; set; }

        public CropDTO Crop { get; set; }

        public string CropId { get; set; }

        public bool ActivateManually { get; set; }

        public bool Activated { get; set; }

        public class CropDTO
        {
            public string Id { get; set; }

            public string Name { get; private set; }

            public int DayFormation { get; private set; }

            public string CoffeeGrowerId { get; private set; }
        }
    }
}
