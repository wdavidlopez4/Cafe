using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Cafe.Configuration.Application.ArduinoServices.CommandArduinoSetUp
{
    public class ArduinoSetUp : IRequest<ArduinoSetUpDTO>
    {
        public string Name { get; set; }

        public string CropId { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
