using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Ports
{
    public interface IUserSecurity
    {
        public string CreateToken(string mail, Guid id, string name);

        public string EncriptAndDecryptPassword(string password);
    }
}
