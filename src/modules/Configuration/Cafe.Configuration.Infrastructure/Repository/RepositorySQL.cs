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
                var entity = context.Set<T>().Update(obj);

                //confirma que se añadio el objeto
                if (await context.SaveChangesAsync(cancellationToken) < 0)
                    throw new Exception($"no se actualizo la entidad en la db: {obj.GetType()}");

                return entity.Entity;
            }
            catch (Exception e)
            {
                throw new Exception($"no se pudo actualizr  la entidad {e.Message}");
            }
        }


    }
}
