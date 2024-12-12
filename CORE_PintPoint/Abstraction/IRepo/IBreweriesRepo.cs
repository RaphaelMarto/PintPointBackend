using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Abstraction.IRepo
{
    public interface IBreweriesRepo : IBaseRepo<Breweries>
    {
        bool post(Breweries breweries);
    }
}
