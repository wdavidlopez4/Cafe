using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Cafe.Configuration.Application.MonitoringServices.CommandMonitoringManualBegin
{
    public class MonitoringManualBegin : IRequest<MonitoringManualBeginDTO>
    {
        public bool ActivateManually { get; set; }

        public string CropId { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
