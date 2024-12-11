using CORE_PintPoint.Entities;

namespace CORE_PintPoint.Abstraction.IService
{
    public interface IBreweriesService : IBaseService<BreweriesWithCountry>
    {
        BreweriesWithCountry GetOne(int id);
    }
}
