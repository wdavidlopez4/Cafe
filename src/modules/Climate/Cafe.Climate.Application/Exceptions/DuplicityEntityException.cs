using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Application.Exceptions
{
    public class DuplicityEntityException : Exception
    {
        public DuplicityEntityException(string message) : base(message)
        {
        }
    }
}
