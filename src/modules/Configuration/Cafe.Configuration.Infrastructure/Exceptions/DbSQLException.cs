using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Infrastructure.Exceptions
{
    public class DbSQLException : Exception
    {
        public DbSQLException(string message): base(message)
        {

        }
    }
}
