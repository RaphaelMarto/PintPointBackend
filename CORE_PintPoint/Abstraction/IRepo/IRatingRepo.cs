using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Abstraction.IRepo
{
    public interface IRatingRepo
    {
        OffsetResult<BeersRating> Get(int offset, int limit, string order, string type, int idUser, int idBeer);
        IEnumerable<BeersRating> GetPopular(int idUser, int idBeer);
        IEnumerable<BeersRating> GetNewest(int idUser, int idBeer);
        bool LikeUnlikeRating(bool likeStatus, int idRating, int idUser);
        IEnumerable<MoyenRate> GetMoyenRate(int idBeer);
    }
}
