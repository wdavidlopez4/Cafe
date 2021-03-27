using Cafe.Configuration.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Entities
{
    public class CoffeeGrower : EntityBase
    {
        public string Name { get; private set; }

        public string Mail { get; private set; }

        public string Password { get; private set; }

        public List<Crop> Crops { get; private set;}

        internal CoffeeGrower(string name, string mail, string password, List<Crop> crops = null): base()
        {
            this.Name = name;
            this.Mail = mail;
            this.Password = password;
            this.Crops = crops;

            if (Validator.Validate<CoffeeGrower>(this, CropValidation.Validation) == false)
                throw new ArgumentException("la entidad se valido como erronea.");
        }

        private CoffeeGrower()
        {
            //for IF
        }
    }
}
