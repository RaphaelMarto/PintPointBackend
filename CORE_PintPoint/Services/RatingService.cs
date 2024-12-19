using CORE_PintPoint.Abstraction.IRepo;
using CORE_PintPoint.Abstraction.IService;
using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepo _RatingRepo;

        public RatingService(IRatingRepo ratingRepo)
        {
            _RatingRepo = ratingRepo;
        }
        public OffsetResult<BeersRating> Get(int offset, int limit, string order, string type, int idUser, int idBeer)
        {
            OffsetResult<BeersRating> RatingOffset = _RatingRepo.Get(offset, limit, order, type, idUser, idBeer);
            RatingOffset.Results = isLiked(RatingOffset.Results);
            return RatingOffset;
        }

        public IEnumerable<MoyenRate> GetMoyenRate(int idBeer)
        {
            return _RatingRepo.GetMoyenRate(idBeer);
        }

        public IEnumerable<BeersRating> GetNewest(int idUser, int idBeer)
        {
            IEnumerable<BeersRating> ratings = _RatingRepo.GetNewest(idUser, idBeer);
            ratings = isLiked(ratings);
            return ratings;
        }

        public IEnumerable<BeersRating> GetPopular(int idUser, int idBeer)
        {
            IEnumerable<BeersRating> ratings = _RatingRepo.GetPopular(idUser, idBeer);
            ratings = isLiked(ratings);
            return ratings;
        }

        public IEnumerable<BeersRating> isLiked(IEnumerable<BeersRating> ratings)
        {
            foreach (BeersRating rating in ratings)
            {
                if (rating.Liked == null)
                {
                    rating.Liked = false;
                }
            }

            return ratings;
        }

        public bool LikeUnlikeRating(bool likeStatus, int idRating, int idUser)
        {
            return _RatingRepo.LikeUnlikeRating(likeStatus, idRating, idUser);
        }
    }
}
