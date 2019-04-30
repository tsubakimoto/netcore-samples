using System;
using System.Collections.Generic;

namespace CrudCacheSample
{
    public class ReadCaching<TEntity> : IRead<TEntity>
    {
        private readonly IRead<TEntity> decorated;
        private Dictionary<Guid, TEntity> cachedEntities = new Dictionary<Guid, TEntity>();
        private IEnumerable<TEntity> allCachedEntities;

        public ReadCaching(IRead<TEntity> decorated)
        {
            this.decorated = decorated;
        }

        public IEnumerable<TEntity> ReadAll()
        {
            if (allCachedEntities == null)
            {
                allCachedEntities = decorated.ReadAll();
            }
            return allCachedEntities;
        }
        public TEntity ReadOne(Guid identity)
        {
            var foundEntity = cachedEntities[identity];
            if (foundEntity == null)
            {
                foundEntity = decorated.ReadOne(identity);
                if (foundEntity != null)
                    cachedEntities[identity] = foundEntity;
            }
            return foundEntity;
        }
    }
}
