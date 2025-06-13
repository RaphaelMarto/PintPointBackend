using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Abstraction.IRepo
{
    public interface IAuthRepo
    {
        Users Register(UserWithAddress userWithAddress);
        int Login(string email, string password);
        Users GetOne(int id);
        string GetPassword(string email);
        bool UpdateTokenDb(int idUser, string token, string refreshToken);
        bool CheckRefresh(string accessToken, string refreshToken);
        EmailNickNameExist CheckUserExists(string nickName, string email);
        bool UpdatePassword(int idUser, string password);
        bool DeleteUser(int idUser, string email);
    }
}
