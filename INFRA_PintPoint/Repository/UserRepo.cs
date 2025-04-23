using CORE_PintPoint.Abstraction.IRepo;
using Dapper;
using Domain_PintPoint.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
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

        public UserPP? GetUserPP(string nickName)
        {
            string storedProcedure = "SP_GetOne_User_Profil";
            return _connection.QuerySingleOrDefault<UserPP>(storedProcedure, new { NickName = nickName });
        }

        public UserWithAddress? GetUserProfile(int idUser)
        {
            string storedProcedure = "SP_GetOne_UserUpdate";
            return _connection.QuerySingleOrDefault<UserWithAddress>(storedProcedure, new { id = idUser });
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

        public bool UpdateUserAddress(UserAddress userAddress)
        {
            string storedProcedure = "SP_Put_UserAddress";
            return _connection.Execute(storedProcedure, new { 
                Id = userAddress.AddressId, 
                IdCity = userAddress.IdCity, 
                HouseNumber = userAddress.HouseNumber, 
                PostCode = userAddress.PostCode, 
                Street = userAddress.Street }) > 0;
        }

        public bool UpdateUserProfile(UserUpdate userUpdate, int idUser)
        {
            string storedProcedure = "SP_Put_UserUpdate";
            return (_connection.Execute(storedProcedure, new
            {
                Id = idUser,
                FirstName = userUpdate.FirstName,
                LastName = userUpdate.LastName,
                NickName = userUpdate.NickName,
                DateOfBirth = userUpdate.DateOfBirth,
                Email = userUpdate.Email,
                Phone = userUpdate.Phone
            }) > 0);
        }
    }
}
