using CORE_PintPoint.Abstraction.IRepo;
using CORE_PintPoint.Abstraction.IService;
using Domain_PintPoint.Entities;
using BC = BCrypt.Net;

namespace CORE_PintPoint.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepo _AuthRepo;
        public AuthService(IAuthRepo Repo)
        {
            _AuthRepo = Repo;
        }

        public bool CheckRefresh(string accessToken, string refreshToken)
        {
            return _AuthRepo.CheckRefresh(accessToken, refreshToken);
        }

        public EmailNickNameExist CheckUserExists(string nickName, string email)
        {
            return _AuthRepo.CheckUserExists(nickName, email);
        }

        public bool DeleteUser(int idUser, string email)
        {
            return _AuthRepo.DeleteUser(idUser, email);
        }

        public Users GetOne(int id)
        {
            return _AuthRepo.GetOne(id);
        }

        public int Login(string email, string password)
        {
            string dbPwd = _AuthRepo.GetPassword(email);
            if (BC.BCrypt.Verify(password, dbPwd))
            {
                return _AuthRepo.Login(email, dbPwd);
            }
            throw new Exception("Wrong credentials");
        }

        public Users Register(UserWithAddress userWithAddress)
        {
            string salt = BC.BCrypt.GenerateSalt();
            string hashedPassword = BC.BCrypt.HashPassword(userWithAddress.Password, salt);
            userWithAddress.Password = hashedPassword;
            return _AuthRepo.Register(userWithAddress);
        }

        public bool UpdatePassword(int idUser, string password, string oldPassword, string email)
        {
            string dbPwd = _AuthRepo.GetPassword(email);
            if (BC.BCrypt.Verify(oldPassword, dbPwd))
            {
                string salt = BC.BCrypt.GenerateSalt();
                return _AuthRepo.UpdatePassword(idUser, BC.BCrypt.HashPassword(password, salt));
            }
            throw new Exception("Password inccorect");
        }

        public bool UpdateTokenDb(int idUser, string token, string refreshToken)
        {
            return _AuthRepo.UpdateTokenDb(idUser, token, refreshToken);
        }
    }
}
