using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Cafe.Configuration.Application.MonitoringServices.CommandMonitoringImageBegin
{
    public class MonitoringImageBegin : IRequest<MonitoringImageBeginDTO>
    {
        public string ActivateByImage { get; set; }

        public string CropId { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
