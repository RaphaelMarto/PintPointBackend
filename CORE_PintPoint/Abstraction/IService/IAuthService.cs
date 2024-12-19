using Domain_PintPoint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_PintPoint.Abstraction.IService
{
    public interface IAuthService
    {
        Users Register(UserWithAddress userWithAddress);
        int Login(string email, string password);
        Users GetOne(int id);
        bool UpdateTokenDb(int idUser, string token, string refreshToken);
        bool CheckRefresh(string accessToken, string refreshToken);
        EmailNickNameExist CheckUserExists(string nickName, string email);
    }
}
