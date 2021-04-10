using AutoMapper;
using Cafe.Configuration.Domain.Ports;
using Cafe.Configuration.Infrastructure.Exceptions;
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
            try
            {
                return mapper.Map<TSource, TDestination>(source);
            }
            catch (Exception e)
            {

                throw new AutoMappingException($"no se pudo mapear la entidad: {e.Message}");
            }
        }
    }
}
