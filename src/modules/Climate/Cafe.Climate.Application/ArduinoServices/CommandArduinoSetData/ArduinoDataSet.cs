using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Cafe.Climate.Application.ArduinoServices.CommandArduinoSetData
{
    public class ArduinoDataSet : IRequest<ArduinoDataSetDTO>
    {
        public string CropId { get; set; }

        public double Temperature { get; set; }

        public double Humididy { get; set; }

        public double Altitude { get; set; }

        public DateTime Time { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
