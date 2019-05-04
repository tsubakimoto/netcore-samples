using CacheRepositorySample.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CacheRepositorySample.Repositories
{
    public abstract class EfRepository<TEntity> : IRead<TEntity>, ICreateUpdate<TEntity> where TEntity : class
    {
        protected readonly CacheRepositorySampleContext db;

        public EfRepository(CacheRepositorySampleContext db) => this.db = db;

        public void Create(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            db.SaveChanges();
        }
        public IEnumerable<TEntity> ReadAll() => db.Set<TEntity>().AsEnumerable();
        public TEntity ReadOne(int identity) => db.Set<TEntity>().Find();
        public void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Unchanged;
            db.SaveChanges();
        }
    }
}
