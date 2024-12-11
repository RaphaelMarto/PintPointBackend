namespace CORE_PintPoint.Abstraction.IService
{
    public interface IBaseService<TEntities>
    {
        IEnumerable<TEntities> GetAll();
    }
}
