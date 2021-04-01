﻿using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Cafe.Configuration.Domain.Validations;

namespace Cafe.Configuration.Domain.Factories
{
    public class Factory : IFactory
    {
        public EntityBase CreateCoffeeGrower(string name, string mail, string password, string token, List<Crop> crops = null, Guid? id = null)
        {
            return new CoffeeGrower(name, mail, password, token, crops, id);
        }

        public EntityBase CreateCrop(string nombre, int diasFormacion, string coffeeGrowerId, string configurationCropId = null)
        {
            return new Crop(nombre, diasFormacion, coffeeGrowerId, configurationCropId);
        }
    }
}
