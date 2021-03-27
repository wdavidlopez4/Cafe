using AutoMapper;
using Cafe.Configuration.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Infrastructure.Mapping
{
    public class AutoMapping : IAutoMapping
    {
        private readonly IMapper mapper;

        public AutoMapping(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return mapper.Map<TSource, TDestination>(source);
        }
    }
}
