using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.Exceptions
{
    /// <summary>
    /// cuando no se pudo encriptar
    /// </summary>
    public class EncriptException : Exception
    {
        public EncriptException(string message) : base(message)
        {

        }
    }
}
