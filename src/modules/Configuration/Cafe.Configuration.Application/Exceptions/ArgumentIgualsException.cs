using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.Exceptions
{
    public class ArgumentIgualsException : Exception
    {
        public ArgumentIgualsException(string message): base(message)
        {

        }
    }
}
