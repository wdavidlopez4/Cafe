using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Validations
{
    public class CoffeeGrowerValidation
    {
        internal static readonly Predicate<CoffeeGrower>[] Validation =
        {
            //si el id es vacio o nulo
            (c) => c.Id != null && c.Id != "",

            //si el nombre es vacio o nulo
            (c) => c.Name != null && c.Name != "",

            //si el correo es vacio o nulo
            (c) => c.Mail != null && c.Mail != "",

            //si la contraseña es vacio o nula
            (c) => c.Password != null && c.Password != "",

            //si el token es vacia o nula
            (c) => c.Token != null && c.Token != ""
        };
    }
}
