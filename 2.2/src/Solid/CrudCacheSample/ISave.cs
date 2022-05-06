namespace CrudCacheSample
{
    public interface ISave<TEntity>
    {
        void Save(TEntity entity);
    }
}
