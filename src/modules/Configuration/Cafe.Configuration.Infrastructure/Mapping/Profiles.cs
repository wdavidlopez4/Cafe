using AutoMapper;
using Cafe.Configuration.Application.ArduinoServices.CommandArduinoSetUp;
using Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerLogin;
using Cafe.Configuration.Application.CoffeeGrowerServices.CommandCoffeGrowerSignIn;
using Cafe.Configuration.Application.CropServices.CommandCropCreate;
using Cafe.Configuration.Application.CropServices.QueryCropById;
using Cafe.Configuration.Application.CropServices.QueryCropByPage;
using Cafe.Configuration.Application.SetUpServices.QuerySetUpByIdCrop;
using Cafe.Configuration.Application.TemperatureServices.CommandTemperatureSetUp;
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
            this.CreateMap<Crop, CropByIdDTO>();
            this.CreateMap<Crop, CropByPageDTO>();
            this.CreateMap<Temperature, TemperatureSetUpDTO>();
            this.CreateMap<Arduino, ArduinoSetUpDTO>();
            this.CreateMap<ConfigurationCrop, ArduinoSetUpDTO.ConfigurationCropDTO>();
            this.CreateMap<CoffeeGrower, CropByIdDTO.CoffeeGrowerDTO>();
            this.CreateMap<ConfigurationCrop, CropByIdDTO.ConfigurationCropDTO>();
            this.CreateMap<CoffeeGrower, CropByPageDTO.CoffeeGrowerDTO>();
            this.CreateMap<ConfigurationCrop, TemperatureSetUpDTO.ConfigurationCropDTO>();
            this.CreateMap<ConfigurationCrop, SetUpByIdCropDTO>();
            this.CreateMap<Crop, SetUpByIdCropDTO.CropDTO>();
            this.CreateMap<Temperature, SetUpByIdCropDTO.TemperatureDTO>();
            this.CreateMap<Arduino, SetUpByIdCropDTO.ArduinoDTO>();

        }
    }
}
