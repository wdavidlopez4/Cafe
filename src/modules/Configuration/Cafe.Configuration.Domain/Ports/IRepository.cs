﻿using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Configuration.Domain.Ports
{
    public interface IRepository
    {
        /// <summary>
        /// almacena el objeto en la db
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Task<T> Save<T>(T obj, CancellationToken cancellationToken) where T : EntityBase;
    }
}
