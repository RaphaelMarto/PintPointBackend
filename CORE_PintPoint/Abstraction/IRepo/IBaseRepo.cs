namespace CORE_PintPoint.Abstraction.IRepo
{
    public interface IBaseRepo<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
    }
}
