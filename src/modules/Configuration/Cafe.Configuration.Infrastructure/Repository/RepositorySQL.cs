using Cafe.Configuration.Domain.Entities;
using Cafe.Configuration.Domain.Ports;
using Cafe.Configuration.Infrastructure.EFcore;
using System;
using System.Collections.Generic;
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
    }
}
