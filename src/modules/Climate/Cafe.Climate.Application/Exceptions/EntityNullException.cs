using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Application.Exceptions
{
    public class EntityNullException : Exception
    {
        public EntityNullException(string message) : base(message)
        {

        }
    }
}
