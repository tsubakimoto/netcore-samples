using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CrudSample
{
    public class CrudLogging<TEntity> : ICrud<TEntity>
    {
        private readonly ICrud<TEntity> decoratedCrud;
        private readonly ILogger<CrudLogging<TEntity>> log;

        public CrudLogging(ICrud<TEntity> decoratedCrud, ILogger<CrudLogging<TEntity>> log)
        {
            this.decoratedCrud = decoratedCrud;
            this.log = log;
        }

        public void Create(TEntity entity)
        {
            log.LogInformation("create");
            decoratedCrud.Create(entity);
        }
        public void Delete(TEntity entity)
        {
            log.LogInformation("delete");
            decoratedCrud.Delete(entity);
        }
        public IEnumerable<TEntity> ReadAll()
        {
            log.LogInformation("read all");
            return decoratedCrud.ReadAll();
        }
        public TEntity ReadOne(Guid identity)
        {
            log.LogInformation("read one");
            return decoratedCrud.ReadOne(identity);
        }
        public void Update(TEntity entity)
        {
            log.LogInformation("update");
            decoratedCrud.Update(entity);
        }
    }
}
