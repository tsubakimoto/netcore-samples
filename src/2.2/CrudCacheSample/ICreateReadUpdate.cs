using System;
using System.Collections.Generic;

namespace CrudCacheSample
{
    public interface ICreateReadUpdate<TEntity>
    {
        void Create(TEntity entity);
        TEntity ReadOne(Guid identity);
        IEnumerable<TEntity> ReadAll();
        void Update(TEntity entity);
    }
}
