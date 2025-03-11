using Domain_PintPoint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_PintPoint.Abstraction.IRepo
{
    public interface IUserRepo
    {
        IEnumerable<Top3Rate> getTop3(int idUser);
        UserProfile? GetUserProfile(string nickName);
        int getUserId(string nickName);
        OffsetResult<BeersRating> RatingBeerUser(int offset, int limit, string order, string type, int idUser);
        IEnumerable<BeersRating> GetRecentRating(int idUser);
    }
}
