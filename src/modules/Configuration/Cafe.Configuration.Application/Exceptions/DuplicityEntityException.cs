using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.Exceptions
{
    /// <summary>
    /// establese una exepcion para evitar que se existan mas de una entidad con el mismo proposito.
    /// </summary>
    public class DuplicityEntityException : Exception
    {
        public DuplicityEntityException(string message): base(message)
        {
        }
    }
}
