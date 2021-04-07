using Cafe.Configuration.Domain.Entities;
using Cafe.Configuration.Domain.Ports;
using Cafe.Configuration.Infrastructure.EFcore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Configuration.Infrastructure.Repository
{
    public class RepositorySQL : IRepository
    {
        private readonly CoffeeContext context;

        public RepositorySQL(CoffeeContext context)
        {
            this.context = context;
        }

        public async Task<T> Save<T>(T obj, CancellationToken cancellationToken) where T : EntityBase
        {
            try
            {
                var entity = await context.Set<T>().AddAsync(obj, cancellationToken);

                //confirma que se añadio el objeto
                if (await context.SaveChangesAsync(cancellationToken) < 0)
                    throw new Exception($"no se guardo la entidad en la db: {obj.GetType()}");

                return entity.Entity;
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
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

        public async Task<T> Get<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken) where T : EntityBase
        {
            try
            {
                return await context.Set<T>().FirstOrDefaultAsync(expression, cancellationToken);
            }
            catch (Exception e)
            {

                throw new Exception($"no se pudo recuperar la entidad {e.Message}");
            }
        }

        public async Task<T> Update<T>(T obj, CancellationToken cancellationToken) where T : EntityBase
        {
            try
            {
                context.Entry(await context.Set<T>().FirstOrDefaultAsync(x => x.Id == obj.Id)).CurrentValues.SetValues(obj);

                if (await context.SaveChangesAsync(cancellationToken) < 0)
                    throw new Exception($"no se actualizo la entidad en la db: {obj.GetType()}");

                return await context.Set<T>().FirstOrDefaultAsync(x => x.Id == obj.Id);
            }
            catch (Exception e)
            {
                throw new Exception($"no se pudo actualizr  la entidad {e.Message}");
            }
        }

        public async Task<T> GetWithNestedObject<T>(Expression<Func<T, bool>> expressionConditional,
            Expression<Func<T, object>> expressionNested, CancellationToken cancellationToken) where T : EntityBase
        {
            try
            {
                return await context.Set<T>().Include(expressionNested).FirstOrDefaultAsync(expressionConditional, cancellationToken);
            }
            catch (Exception e)
            {

                throw new Exception($"no se pudo recuperar la entidad {e.Message}");
            }
        }

        public async Task<List<T>> GetAllBy<T>(Expression<Func<T, string>> sort, int page, int pageSize, 
            Expression<Func<T, object>> expressionNested, Expression<Func<T, bool>> expressionConditional, 
            CancellationToken cancellationToken) where T : EntityBase
        {
            try
            {
                int skipRows = (page) * pageSize;
                return await context.Set<T>()
                    .Include(expressionNested)
                    .Where(expressionConditional)
                    .OrderBy(sort)
                    .Skip(skipRows)
                    .Take(pageSize)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception($"no se pudo actualizr  la entidad {e.Message}");
            }
        }

        public async Task<T> GetWithNestedObjects<T>(CancellationToken cancellationToken, Expression<Func<T, bool>> expressionConditional,
            params Expression<Func<T, object>>[] expressionsNested) where T : EntityBase
        {

            var contextQuery = this.context as IQueryable<T>; // _dbSet = dbContext.Set<TEntity>()
            var query = expressionsNested.Aggregate(contextQuery, (current, property) => current.Include(property));

            return await query.AsNoTracking().FirstOrDefaultAsync(expressionConditional, cancellationToken);
        }

    }
}
