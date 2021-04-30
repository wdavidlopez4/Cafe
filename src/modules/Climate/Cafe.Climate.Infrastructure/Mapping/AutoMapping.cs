using AutoMapper;
using Cafe.Climate.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Infrastructure.Mapping
{
    class AutoMapping : IAutoMapping
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

                throw new Exception($"no se pudo mapear la entidad: {e.Message}");
            }
        }
    }
}
