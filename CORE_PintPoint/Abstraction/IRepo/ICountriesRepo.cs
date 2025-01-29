using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Abstraction.IRepo
{
    public interface ICountriesRepo : IBaseRepo<Countries>
    {
        //Task<string> GetFlag(string name);
        IEnumerable<Cities> GetCities();
    }
}
