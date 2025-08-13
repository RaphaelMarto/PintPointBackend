using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Abstraction.IRepo
{
    public interface IBeersRepo
    {
        OffsetResult<Beers> Get(int offset, int limit, string order, string type, string search);
        Beers GetOne(int id, int idUser);
        bool post(Beers beers);
        bool Update(Beers beers);
    }
}
