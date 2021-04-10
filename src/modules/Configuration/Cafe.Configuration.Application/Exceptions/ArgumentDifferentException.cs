using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.Exceptions
{
    /// <summary>
    /// argumentos simplemente diferentes.
    /// </summary>
    public class ArgumentDifferentException : Exception
    {
        public ArgumentDifferentException(string message): base(message)
        {

        }
    }
}
