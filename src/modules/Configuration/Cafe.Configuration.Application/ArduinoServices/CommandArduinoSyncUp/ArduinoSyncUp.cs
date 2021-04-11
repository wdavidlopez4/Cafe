using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Cafe.Configuration.Application.ArduinoServices.CommandArduinoSyncUp
{
    public class ArduinoSyncUp : IRequest<ArduinoSyncUpDTO>
    {
        public string Id { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
