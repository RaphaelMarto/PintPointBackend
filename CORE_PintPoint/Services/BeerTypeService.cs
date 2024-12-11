using CORE_PintPoint.Abstraction.IRepo;
using CORE_PintPoint.Abstraction.IService;
using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Services
{
    public class BeerTypeService : IBeerTypeService
    {
        private readonly IBeerTypeRepo _BeerTypeRepo;
        public BeerTypeService(IBeerTypeRepo Repo)
        {
            _BeerTypeRepo = Repo;
        }
        public IEnumerable<BeerType> GetAll()
        {
            return _BeerTypeRepo.Get();
        }
    }
}
