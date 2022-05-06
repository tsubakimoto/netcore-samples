namespace CacheRepositorySample
{
    public interface ICreateUpdate<TEntity>
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
    }
}
