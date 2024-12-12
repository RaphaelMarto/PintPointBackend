using CORE_PintPoint.Abstraction.IRepo;
using CORE_PintPoint.Abstraction.IService;
using CORE_PintPoint.Entities;
using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Services
{
    public class BreweriesService : IBreweriesService
    {
        private readonly IBreweriesRepo _BreweriesRepo;
        private readonly ICountriesRepo _CountriesRepo;
        public BreweriesService(IBreweriesRepo RepoBreweries, ICountriesRepo countriesRepo)
        {
            _BreweriesRepo = RepoBreweries;
            _CountriesRepo = countriesRepo;
        }
        public IEnumerable<BreweriesWithCountry> GetAll()
        {
            List<BreweriesWithCountry> breweries = _BreweriesRepo.Get().Select(b => new BreweriesWithCountry(b)).ToList();

            for (int i = 0; i < breweries.Count; i++)
            {
                breweries[i].CountryName = _CountriesRepo.Get(breweries[i].IdCountry).Name;
            }

            return breweries;
        }

        public BreweriesWithCountry GetOne(int id)
        {
            BreweriesWithCountry brewery = new BreweriesWithCountry(_BreweriesRepo.Get(id));
            brewery.CountryName = _CountriesRepo.Get(brewery.IdCountry).Name;

            return brewery;
        }

        public bool Post(Breweries breweries)
        {
            return _BreweriesRepo.post(breweries);
        }
    }
}
