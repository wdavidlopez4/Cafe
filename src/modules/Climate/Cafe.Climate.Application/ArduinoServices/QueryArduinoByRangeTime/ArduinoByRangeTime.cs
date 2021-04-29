using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Cafe.Climate.Application.ArduinoServices.QueryArduinoByRangeTime
{
    public class ArduinoByRangeTime : IRequest<List<ArduinoByRangeTimeDTO>>
    {
        public string CropId { get; set; }

        public DateTime RangeTimelower { get; set; }

        public DateTime RangeTimeUpper { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
