using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.Exceptions
{
    public class MonitoringRunningException : Exception
    {
        public MonitoringRunningException(string message):base(message)
        {

        }
    }
}
