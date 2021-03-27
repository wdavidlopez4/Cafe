using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Domain.Ports
{
    public interface IAutoMapping
    {
        public TDestination Map<TSource, TDestination>(TSource source);
    }
}
