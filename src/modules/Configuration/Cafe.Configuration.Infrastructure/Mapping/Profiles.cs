using AutoMapper;
using Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerCreate;
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
            this.CreateMap<CoffeeGrower, CoffeeGrowerCreateDTO>();
        }
    }
}
