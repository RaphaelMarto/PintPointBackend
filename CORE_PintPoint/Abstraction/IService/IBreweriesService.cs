using CORE_PintPoint.Entities;
using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Abstraction.IService
{
    public interface IBreweriesService : IBaseService<BreweriesWithCountry>
    {
        BreweriesWithCountry GetOne(int id);
        bool Post(Breweries breweries);
    }
}
