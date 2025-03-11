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
        bool PostRating(decimal rate, string comment, int idBeer, int idUser);
        MyRating? GetOneRating(int idBeer, int idUser);
        bool PutRating(decimal rate, string comment, int idBeer, int idUser);
        IEnumerable<Top3Rate> GetTop3Rate();
    }
}
