using Domain_PintPoint.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API_PintPoint.Service
{
    public class AuthenticateService
    {

        private IConfiguration _config;
        public AuthenticateService(IConfiguration config)
        {
            _config = config;
        }
        public string CreateToken(Users user)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:secretKey"]));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["jwt:issuer"],
                audience: _config["jwt:audience"],
                claims: new List<Claim>() { new Claim(ClaimTypes.Email, user.Email), new Claim(ClaimTypes.Sid, user.Id.ToString()), new Claim(ClaimTypes.Role, user.IsAdmin == true ? "Admin" : "User") },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            string tokenToSend = new JwtSecurityTokenHandler().WriteToken(token);
            user.AccessToken = tokenToSend;
            user.RefreshToken = GenerateRefreshToken();
            return tokenToSend;
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public string GenerateAccessTokenFromRefreshToken(List<Claim>? mesClaims)
        {

            //Générer le token et le renvoyer
            //1- string key vers byte key
            byte[] skey = Encoding.UTF8.GetBytes(_config["jwt:secretKey"]);
            SymmetricSecurityKey laCle = new SymmetricSecurityKey(skey);


            JwtSecurityToken Token = new JwtSecurityToken(
                issuer: _config["jwt:issuer"],
                audience: _config["jwt:audience"],
                claims: mesClaims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: new SigningCredentials(laCle, SecurityAlgorithms.HmacSha256)

            );


            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
