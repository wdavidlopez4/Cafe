using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.Exceptions
{
    /// <summary>
    /// cuando no se pudo crear el token
    /// </summary>
    public class TokenException : Exception
    {
        public TokenException(string message) : base(message)
        {

        }
    }
}
