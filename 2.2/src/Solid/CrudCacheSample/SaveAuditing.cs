namespace CrudCacheSample
{
    public class SaveAuditing<TEntity> : ISave<TEntity>
    {
        private readonly ISave<TEntity> decorated;
        private readonly ISave<AuditInfo> auditSave;

        public SaveAuditing(ISave<TEntity> decorated, ISave<AuditInfo> auditSave)
        {
            this.decorated = decorated;
            this.auditSave = auditSave;
        }

        public void Save(TEntity entity)
        {
            decorated.Save(entity);
            auditSave.Save(new AuditInfo
            {

            });
        }
    }
}
