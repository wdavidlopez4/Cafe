using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Application.Exceptions
{
    public class TokenException : Exception
    {
        public TokenException(string descripcion) : base(descripcion)
        {

        }
    }
}
