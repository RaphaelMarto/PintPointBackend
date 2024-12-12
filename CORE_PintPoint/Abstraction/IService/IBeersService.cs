using CORE_PintPoint.Entities;
using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Abstraction.IService
{
    public interface IBeersService
    {
        OffsetResult<BeersWithNames> GetAll(int offset, int limit, string order, string type, string search);
        BeersWithNames GetOne(int id);
        bool Post(Beers beer);
    }
}
