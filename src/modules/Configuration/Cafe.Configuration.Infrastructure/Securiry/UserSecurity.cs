using Cafe.Configuration.Domain.Ports;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Cafe.Configuration.Infrastructure.Securiry
{
    public class UserSecurity : IUserSecurity
    {
        private readonly IConfiguration configuration;

        public UserSecurity(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// crea un token para que el usuario pueda loguearse o ingresar
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string CreateToken(string mail, Guid id, string name)
        {
            //creamos el cleims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, mail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("nombre", name),
                new Claim("CoffeeGrowerId", id.ToString())
            };

            //obtener variables de entorno
            string secret = this.configuration["CLAVE_SECRETA"];
            string domain = this.configuration["DOMINIO_APP"];
            string DayString = this.configuration["DIAS_EXPIRACION"];
            int DayExpires = int.Parse(DayString);

            //verificar variables de entorno
            if (secret == null || secret == "")
                throw new Exception("la clave de seguridad nunca se instancio...");
            else if(domain == null || domain == "")
                throw new Exception("el dominio para el token nunca se instancio...");
            else if (DayString == null || DayString == "")
                throw new Exception("los dias de expiracion para el token nunca se instancio...");

            //encriptar clave secreta,crear credenciales y dias de expiracion
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issues = DateTime.UtcNow.AddDays(DayExpires); //expide

            //creamos el token con los datos anteriores
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: domain,
                audience: domain,
                claims: claims,
                expires: issues,//expide
                signingCredentials: credential
                );

            //retornamos el token tipo string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// encripta el password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string EncriptAndCheckPassword(string password)
        {
            CheckPasswork(password);

            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        private void CheckPasswork(string password)
        {
            if (password == null)
                throw new ArgumentNullException("la contraseña es nula");
            else if (password == "")
                throw new ArgumentNullException("0 caracteres para la contraseña");
            else if (password.Length < 7)
                throw new ArgumentNullException("la contraseña es muy corta debe por lo menos tener 7 caracteres.");
        }

        /// <summary>
        /// validacion del token
        /// </summary>
        /// <param name="jwtToken"></param>
        /// <returns></returns>
        public string GetClaim(string token, string claimType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var stringClaimValue = securityToken.Claims.First(claim => claim.Type == claimType).Value;
            return stringClaimValue;
        }
    }
}
