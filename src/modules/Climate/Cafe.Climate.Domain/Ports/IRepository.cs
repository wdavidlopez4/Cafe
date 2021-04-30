using Cafe.Climate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Climate.Domain.Ports
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
        /// <param name="expressionConditional"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<T>> GetObjects<T>( Expression<Func<T, bool>> expressionConditional, 
            CancellationToken cancellationToken) where T : EntityBase;
    }
}
