using CORE_PintPoint.Abstraction.IRepo;
using Dapper;
using Domain_PintPoint.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRA_PintPoint.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly SqlConnection _connection;
        public UserRepo(SqlConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<BeersRating> GetRecentRating(int idUser)
        {
            string storedProcedure = "SP_List_Rating_User_Recent";
            return _connection.Query<BeersRating>(storedProcedure, new { IdUser = idUser });
        }

        public IEnumerable<Top3Rate> getTop3(int idUser)
        {
            string storedProcedure = "SP_List_Top3_User";
            return _connection.Query<Top3Rate>(storedProcedure, new { UserId = idUser });
        }

        public int getUserId(string nickName)
        {
            string storedProcedure = "SP_GetOne_Id_By_NickName";
            return _connection.QuerySingleOrDefault<int>(storedProcedure, new { NickName = nickName });
        }

        public UserProfile? GetUserProfile(string nickName)
        {
            string storedProcedure = "SP_GetOne_User_Profil";
            return _connection.QuerySingleOrDefault<UserProfile>(storedProcedure, new { NickName = nickName });
        }

        public OffsetResult<BeersRating> RatingBeerUser(int offset, int limit, string order, string type, int idUser)
        {
            string storedProcedure = "SP_List_Rating_User";
            var param = new { Offset = offset, Limit = limit, Order = order, Type = type, IdUser = idUser };

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
    }
}
