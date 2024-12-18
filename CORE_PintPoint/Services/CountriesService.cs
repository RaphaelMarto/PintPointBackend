using CORE_PintPoint.Abstraction.IRepo;
using CORE_PintPoint.Abstraction.IService;
using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly ICountriesRepo _CountriesRepo;

        public CountriesService(ICountriesRepo countriesRepo)
        {
            _CountriesRepo = countriesRepo;
        }

        public IEnumerable<Countries> GetAll()
        {
            return _CountriesRepo.Get();
        }

        public IEnumerable<Cities> GetCities()
        {
            return _CountriesRepo.GetCities();
        }
    }
}
