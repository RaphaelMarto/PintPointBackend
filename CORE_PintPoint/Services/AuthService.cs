using CORE_PintPoint.Abstraction.IRepo;
using CORE_PintPoint.Abstraction.IService;
using Domain_PintPoint.Entities;
using System.Security.Cryptography;
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
            userWithAddress.VerificationCode = RNG(50);
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

        public bool UpdateTokenDb(int idUser, string token, string refreshToken, bool rememberMe)
        {
            return _AuthRepo.UpdateTokenDb(idUser, token, refreshToken, rememberMe);
        }

        public string RNG(int size)
        {
            var randomNumber = new byte[size];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public bool VerifyOne(string code, int id)
        {
            return _AuthRepo.VerifyOne(code, id);
        }

        public bool updatePasswordBycode(string code, int id, string newPassword)
        {
            Users user = this.GetOne(id);
            if (user.PasswordResetCodeExpiration < DateTime.Now)
            {
                throw new Exception("Password reset code has expired");
            }
            string salt = BC.BCrypt.GenerateSalt();
            return _AuthRepo.UpdatePasswordByCode(code, id, BC.BCrypt.HashPassword(newPassword, salt));
        }

        public bool GeneratePwdCode(int id)
        {
            return _AuthRepo.GeneratePwdCode(id, RNG(50));
        }

        public int GetIdByMail(string mail)
        {
            return _AuthRepo.GetIdByMail(mail);
        }

        public bool UpdateRefreshTokenDb(int idUser, string token, string refreshToken)
        {
            return _AuthRepo.UpdateRefreshTokenDb(idUser, token, refreshToken);
        }
    }
}
