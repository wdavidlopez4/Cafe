﻿using Cafe.Configuration.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Entities
{
    public class Crop : EntityBase
    {
        public string Name { get; private set; }

        public int DayFormation { get; private set; }

        public string CoffeeGrowerId { get; private set; }
        
        public CoffeeGrower CoffeeGrower { get; private set; }

        public ConfigurationCrop ConfigurationCrop { get; private set; }

        internal Crop(string name, int DayFormation, string coffeeGrowerId) : base()
        {
            this.Name = name;
            this.DayFormation = DayFormation;
            this.CoffeeGrowerId = coffeeGrowerId;

            if (Validator.Validate<Crop>(this, CropValidation.Validation) == false)
                throw new ArgumentException("la entidad se valido como erronea.");
        }

        private Crop()
        {
            //ef
        }
    }
}
