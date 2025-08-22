using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Abstraction.IService
{
    public interface IAuthService
    {
        Users Register(UserWithAddress userWithAddress);
        int Login(string email, string password);
        Users GetOne(int id);
        bool UpdateTokenDb(int idUser, string token, string refreshToken, bool rememberMe);
        bool UpdateRefreshTokenDb(int idUser, string token, string refreshToken);
        bool CheckRefresh(string accessToken, string refreshToken);
        EmailNickNameExist CheckUserExists(string nickName, string email);
        bool UpdatePassword(int idUser, string password, string oldPassword, string email);
        bool DeleteUser(int idUser, string email);
        bool VerifyOne(string code, int id);
        bool updatePasswordBycode(string code, int id, string newPassword);
        bool GeneratePwdCode(int id);
        int GetIdByMail(string mail);
    }
}
