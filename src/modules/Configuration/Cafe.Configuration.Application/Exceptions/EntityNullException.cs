using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.Exceptions
{
    /// <summary>
    /// existencia de la entidad
    /// </summary>
    public class EntityNullException : Exception
    {
        public EntityNullException(string message): base(message)
        {

        }
    }
}
