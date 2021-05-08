using AutoMapper;
using Cafe.Climate.Application.ArduinoServices.CommandArduinoSetData;
using Cafe.Climate.Application.ArduinoServices.QueryArduinoByRangeTime;
using Cafe.Climate.Application.TemperatureDegreesDaysServices.CommandDegreesDaysCalculate;
using Cafe.Climate.Application.TemperatureInceptThresholdServices.CommandInceptThresholdCalculate;
using Cafe.Climate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Infrastructure.Mapping
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            this.CreateMap<ArduinoData, ArduinoByRangeTimeDTO>();
            this.CreateMap<ArduinoData, ArduinoDataSetDTO>();
            this.CreateMap<TemperatureInceptThreshold, InceptThresholdCalculateDTO>();
            this.CreateMap<TemperatureDegreesDays, DegreesDaysCalculateDTO>();
        }
    }
}
