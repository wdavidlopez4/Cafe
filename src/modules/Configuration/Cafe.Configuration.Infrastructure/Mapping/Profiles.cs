using AutoMapper;
using Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerLogin;
using Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerSignIn;
using Cafe.Configuration.Application.CropServices.CommandCropCreate;
using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Infrastructure.Mapping
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            this.CreateMap<CoffeeGrower, CoffeeGrowerSignInDTO>();
            this.CreateMap<CoffeeGrower, CoffeGrowerLoginDTO>();
            this.CreateMap<Crop, CropCreateDTO>();
        }
    }
}
