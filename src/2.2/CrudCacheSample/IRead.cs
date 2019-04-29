using System;
using System.Collections.Generic;

namespace CrudCacheSample
{
    public interface IRead<TEntity>
    {
        TEntity ReadOne(Guid identity);
        IEnumerable<TEntity> ReadAll();
    }
}
