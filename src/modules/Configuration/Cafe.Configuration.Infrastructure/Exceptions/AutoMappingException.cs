using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Infrastructure.Exceptions
{
    public class AutoMappingException : Exception
    {
        public AutoMappingException(string message) : base(message)
        {

        }
    }
}
