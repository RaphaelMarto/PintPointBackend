using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Abstraction.IService
{
    public interface IRatingService
    {
        OffsetResult<BeersRating> Get(int offset, int limit, string order, string type, int idUser);
        IEnumerable<BeersRating> GetPopular(int idUser);
        IEnumerable<BeersRating> GetNewest(int idUser);
        IEnumerable<BeersRating> isLiked(IEnumerable<BeersRating> ratings);
        bool LikeUnlikeRating(bool likeStatus, int idRating, int idUser);
        IEnumerable<MoyenRate> GetMoyenRate(int idBeer);
    }
}
