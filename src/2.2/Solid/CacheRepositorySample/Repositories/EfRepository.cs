using CacheRepositorySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheRepositorySample.Repositories
{
    public abstract class EfRepository<TEntity> : IRead<TEntity>, ICreateUpdate<TEntity>
    {
        private readonly CacheRepositorySampleContext db;

        public EfRepository(CacheRepositorySampleContext db)
        {
            this.db = db;
        }

        public void Create(TEntity entity) => throw new NotImplementedException();
        public IEnumerable<TEntity> ReadAll() => throw new NotImplementedException();
        public TEntity ReadOne(int identity) => throw new NotImplementedException();
        public void Update(TEntity entity) => throw new NotImplementedException();
    }
}
