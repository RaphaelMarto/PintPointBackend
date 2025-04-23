using Domain_PintPoint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_PintPoint.Abstraction.IService
{
    public interface IUserService
    {
        IEnumerable<Top3Rate> getTop3(string nickName);
        UserPP? GetUserPP(string nickName);
        OffsetResult<BeersRating> RatingBeerUser(int offset, int limit, string order, string type, string nickName);
        IEnumerable<BeersRating> GetRecentRating(string nickName);
        UserWithAddress? GetUserProfile(string nickName);
        bool UpdateUserProfile(UserUpdate userUpdate, string nickName);
        bool UpdateUserAddress(UserAddress userAddress);
    }
}
