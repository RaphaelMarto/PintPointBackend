using CORE_PintPoint.Abstraction.IRepo;
using Dapper;
using Domain_PintPoint.Entities;
using Microsoft.Data.SqlClient;

namespace INFRA_PintPoint.Repository
{
    public class AuthRepo : IAuthRepo
    {
        private readonly SqlConnection _connection;
        public AuthRepo(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool CheckRefresh(string accessToken, string refreshToken)
        {
            string storedProcedure = "SP_CheckRefresh";
            int? UserId = _connection.QuerySingleOrDefault<int?>(storedProcedure, new { AccessToken = accessToken, RefreshToken = refreshToken });
            return UserId.HasValue;
        }

        public Users GetOne(int id)
        {
            string storedProcedure = "SP_GetOne_User";
            return _connection.QuerySingleOrDefault<Users>(storedProcedure, new { UserId = id });
        }

        public string GetPassword(string email)
        {
            string storedProcedure = "SP_Get_Password";
            return _connection.QuerySingle<string>(storedProcedure, new { Email = email });
        }

        public int Login(string email, string password)
        {
            string storedProcedure = "SP_Sign_In";
            return _connection.QuerySingleOrDefault<int>(storedProcedure, new { Email = email, Password = password });
        }

        public Users Register(UserWithAddress userWithAddress)
        {
            string storedProcedure = "SP_Register";
            var param = new
            {
                FirstName = userWithAddress.FirstName,
                LastName = userWithAddress.LastName,
                NickName = userWithAddress.NickName,
                DateOfBirth = userWithAddress.DateOfBirth,
                Email = userWithAddress.Email,
                Password = userWithAddress.Password,
                Phone = userWithAddress.Phone,
                PictureUrl = userWithAddress.PictureUrl,
                AccessToken = userWithAddress.AccessToken,
                RefreshToken = userWithAddress.RefreshToken,
                PolicyCheck = userWithAddress.PolicyCheck,
                IsAdmin = userWithAddress.IsAdmin,

                IdCity = userWithAddress.IdCity,
                Street = userWithAddress.Street,
                HouseNumber = userWithAddress.HouseNumber,
                PostCode = userWithAddress.PostCode
            };
            return _connection.QuerySingle<Users>(storedProcedure, param);
        }

        public bool UpdateTokenDb(int idUser, string token, string refreshToken)
        {
            string storedProcedure = "SP_UpdateToken";
            return _connection.Execute(storedProcedure, new { UserId = idUser, AccessToken = token, RefreshToken = refreshToken }) > 0;
        }
    }
}
