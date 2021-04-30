using Cafe.Climate.Domain.Entities;
using Cafe.Climate.Domain.Ports;
using Cafe.Climate.Infrastructure.EFcore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Climate.Infrastructure.Repositories
{
    public class RepositorySQL : IRepository
    {
        private readonly ClimateContext context;

        public RepositorySQL(ClimateContext context)
        {
            this.context = context;
        }

        public bool Exists<T>(Expression<Func<T, bool>> expression) where T : EntityBase
        {
            try
            {
                return context.Set<T>().AsQueryable().Any(expression);
            }
            catch (Exception e)
            {

                throw new Exception($"no se pudo verificiar si existe la entidad {e.Message}");
            }
        }

        public Task<List<T>> GetObjects<T>(Expression<Func<T, bool>> expressionConditional, CancellationToken? cancellationToken = null) where T : EntityBase
        {
            try
            {
                return this.context.Set<T>().Where(expressionConditional).ToListAsync(cancellationToken.Value);
            }
            catch (Exception e)
            {

                throw new Exception($"no se pudo recuperar la entidad {e.Message}");
            }
        }

        public async Task<T> GetWithNestedObject<T>(Expression<Func<T, bool>> expressionConditional, Expression<Func<T, object>> expressionNested, CancellationToken? cancellationToken = null) where T : EntityBase
        {
            try
            {
                return await context.Set<T>().Include(expressionNested).FirstOrDefaultAsync(expressionConditional, cancellationToken.Value);
            }
            catch (Exception e)
            {

                throw new Exception($"no se pudo recuperar la entidad {e.Message}");
            }
        }

        public async Task<T> Save<T>(T obj, CancellationToken? cancellationToken = null) where T : EntityBase
        {
            try
            {
                var entity = await context.Set<T>().AddAsync(obj, cancellationToken.Value);

                //confirma que se añadio el objeto
                if (await context.SaveChangesAsync(cancellationToken.Value) < 0)
                    throw new Exception($"no se guardo la entidad en la db: {obj.GetType()}");

                return entity.Entity;
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }

        public async Task<T> Update<T>(T obj, CancellationToken? cancellationToken = null) where T : EntityBase
        {
            try
            {
                context.Entry(await context.Set<T>().FirstOrDefaultAsync(x => x.Id == obj.Id)).CurrentValues.SetValues(obj);

                if (await context.SaveChangesAsync(cancellationToken.Value) < 0)
                    throw new Exception($"no se actualizo la entidad en la db: {obj.GetType()}");

                return await context.Set<T>().FirstOrDefaultAsync(x => x.Id == obj.Id);
            }
            catch (Exception e)
            {
                throw new Exception($"no se pudo actualizr  la entidad {e.Message}");
            }
        }
    }
}
