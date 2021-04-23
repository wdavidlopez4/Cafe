using Cafe.Intelligent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Intelligent.Domain.Factories
{
    public class Factory : IFactory
    {
        public EntityBase CreateImageData(string url, string label)
        {
            throw new NotImplementedException();
        }
    }
}
