using CORE_PintPoint.Abstraction.IRepo;
using CORE_PintPoint.Abstraction.IService;
using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Services
{
    public class BeersService : IBeersService
    {
        private readonly IBeersRepo _BeersRepo;
        public BeersService(IBeersRepo beersRepo)
        {
            _BeersRepo = beersRepo;
        }
        public IEnumerable<Beers> GetAll()
        {
            return _BeersRepo.Get();
        }
    }
}
