﻿using Cafe.Configuration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        /// <summary>
        /// verificar si existe una entidad
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool Exists<T>(Expression<Func<T, bool>> expression) where T : EntityBase;

        /// <summary>
        /// retornar un objeto por medio de una funcion lambda por parametor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> Get<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken) where T : EntityBase;

        /// <summary>
        /// actualizar una entidad
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> Update<T>(T obj, CancellationToken cancellationToken) where T : EntityBase;

        /// <summary>
        /// retorna un objeto anidado, retorna el objeto pero un un solo objeto anidado.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expressionConditional"></param>
        /// <param name="expressionNested"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<T> GetWithNestedObject<T>(Expression<Func<T, bool>> expressionConditional,
            Expression<Func<T, object>> expressionNested, CancellationToken cancellationToken) where T : EntityBase;

        /// <summary>
        /// trae una lista de objetos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sort"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="expressionNested"></param>
        /// <param name="expressionConditional"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<T>> GetAllBy<T>(Expression<Func<T, string>> sort, int page, int pageSize,
            Expression<Func<T, object>> expressionNested, Expression<Func<T, bool>> expressionConditional,
            CancellationToken cancellationToken) where T : EntityBase;

        /// <summary>
        /// obtener un obteto con varios objetos anidados
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cancellationToken"></param>
        /// <param name="expressionConditional"></param>
        /// <param name="expressionsNested"></param>
        /// <returns></returns>
        public Task<T> GetWithNestedObjects<T>(CancellationToken cancellationToken, Expression<Func<T, bool>> expressionConditional,
            params Expression<Func<T, object>>[] expressionsNested) where T : EntityBase;

    }
}
