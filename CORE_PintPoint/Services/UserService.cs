using CORE_PintPoint.Abstraction.IRepo;
using CORE_PintPoint.Abstraction.IService;
using Domain_PintPoint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_PintPoint.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _UserRepo;

        public UserService(IUserRepo userRepo)
        {
            _UserRepo = userRepo;
        }

        public IEnumerable<BeersRating> GetRecentRating(string nickName)
        {
            int id = _UserRepo.getUserId(nickName);
            return _UserRepo.GetRecentRating(id);
        }

        public IEnumerable<Top3Rate> getTop3(string nickName)
        {
            int id = _UserRepo.getUserId(nickName);
            return _UserRepo.getTop3(id);
        }

        public UserProfile? GetUserProfile(string nickName)
        {
            return _UserRepo.GetUserProfile(nickName);
        }

        public OffsetResult<BeersRating> RatingBeerUser(int offset, int limit, string order, string type, string nickName)
        {
            int id = _UserRepo.getUserId(nickName);
            return _UserRepo.RatingBeerUser(offset, limit, order, type, id);
        }
    }
}
