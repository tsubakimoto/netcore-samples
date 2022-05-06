using System;
using System.Collections.Generic;
using System.Transactions;

namespace CrudSample
{
    public class CrudTransactional<TEntity> : ICrud<TEntity>
    {
        private readonly ICrud<TEntity> decoratedCrud;

        public CrudTransactional(ICrud<TEntity> decoratedCrud)
        {
            this.decoratedCrud = decoratedCrud;
        }

        public void Create(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decoratedCrud.Create(entity);
                transaction.Complete();
            }
        }
        public void Delete(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decoratedCrud.Delete(entity);
            }
        }
        public IEnumerable<TEntity> ReadAll()
        {
            IEnumerable<TEntity> allEntities;
            using (var transaction = new TransactionScope())
            {
                allEntities = decoratedCrud.ReadAll();
            }
            return allEntities;
        }
        public TEntity ReadOne(Guid identity)
        {
            TEntity entity;
            using (var transaction = new TransactionScope())
            {
                entity = decoratedCrud.ReadOne(identity);
            }
            return entity;
        }
        public void Update(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decoratedCrud.Update(entity);
            }
        }
    }
}
