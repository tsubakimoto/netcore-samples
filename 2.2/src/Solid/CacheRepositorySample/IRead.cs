using System;
using System.Collections.Generic;

namespace CacheRepositorySample
{
    public interface IRead<TEntity>
    {
        TEntity ReadOne(int identity);
        IEnumerable<TEntity> ReadAll();
    }
}
