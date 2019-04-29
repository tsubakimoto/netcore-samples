using System;
using System.Collections.Generic;

namespace CrudCacheSample
{
    public class CrudCaching<TEntity> : ICreateReadUpdate<TEntity>
    {
        private TEntity cacheEntity;
        private IEnumerable<TEntity> cacheEntities;
        private readonly ICreateReadUpdate<TEntity> decorated;

        public CrudCaching(ICreateReadUpdate<TEntity> decorated)
        {
            this.decorated = decorated;
        }

        public void Create(TEntity entity)
        {
            decorated.Create(entity);
        }
        public IEnumerable<TEntity> ReadAll()
        {
            if (cacheEntities == null)
                cacheEntities = decorated.ReadAll();
            return cacheEntities;
        }
        public TEntity ReadOne(Guid identity)
        {
            if (cacheEntity == null)
                cacheEntity = decorated.ReadOne(identity);
            return cacheEntity;
        }
        public void Update(TEntity entity)
        {
            decorated.Update(entity);
        }
    }
}
