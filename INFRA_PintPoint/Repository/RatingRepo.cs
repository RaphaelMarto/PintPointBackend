using CORE_PintPoint.Abstraction.IRepo;
using Dapper;
using Domain_PintPoint.Entities;
using Microsoft.Data.SqlClient;

namespace INFRA_PintPoint.Repository
{
    public class RatingRepo : IRatingRepo
    {
        private readonly SqlConnection _connection;
        public RatingRepo(SqlConnection connection)
        {
            _connection = connection;
        }

        public OffsetResult<BeersRating> Get(int offset, int limit, string order, string type, int idUser, int idBeer)
        {
            string storedProcedure = "SP_List_Rating";
            var param = new { Offset = offset, Limit = limit, Order = order, Type = type, IdUser = idUser, IdBeer = idBeer };

            using (var multi = _connection.QueryMultiple(storedProcedure, param))
            {
                int total = multi.ReadSingle<int>();
                IEnumerable<BeersRating> ratings = multi.Read<BeersRating>().ToList();

                return new OffsetResult<BeersRating>()
                {
                    Results = ratings,
                    Total = total,
                };
            }
        }

        public IEnumerable<BeersRating> GetNewest(int idUser, int idBeer)
        {
            string storedProcedure = "SP_List_Rating_Newest";
            return _connection.Query<BeersRating>(storedProcedure, new { IdUser = idUser, IdBeer = idBeer });
        }

        public IEnumerable<BeersRating> GetPopular(int idUser, int idBeer)
        {
            string storedProcedure = "SP_List_Rating_Popular";
            return _connection.Query<BeersRating>(storedProcedure, new { IdUser = idUser, IdBeer = idBeer });
        }

        public bool LikeUnlikeRating(bool likeStatus, int idRating, int idUser)
        {
            string storedProcedure = "SP_Post_Like_Rating";
            var param = new { Liked = likeStatus, IdRating = idRating, IdUser = idUser };
            return _connection.Execute(storedProcedure, param) > 0;
        }

        public IEnumerable<MoyenRate> GetMoyenRate(int idBeer)
        {
            string storedProcedure = "SP_List_Moyen_Rating";
            return _connection.Query<MoyenRate>(storedProcedure, new { IdBeer = idBeer });
        }
    }
}
