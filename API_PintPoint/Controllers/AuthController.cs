using API_PintPoint.DTOs.Auth;
using API_PintPoint.Mapper;
using API_PintPoint.Service;
using CORE_PintPoint.Abstraction.IService;
using Domain_PintPoint.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API_PintPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _AuthService;
        private readonly AuthenticateService _AuthenticateService;
        private readonly IMailService _MailService;
        public AuthController(IAuthService AuthService, AuthenticateService authenticateService, IMailService mailService)
        {
            _AuthService = AuthService;
            _AuthenticateService = authenticateService;
            _MailService = mailService;
        }

        [HttpPost("Login")]
        public IActionResult Login(Login login)
        {
            try
            {
                int? id = _AuthService.Login(login.Email, login.Password);
                if (id is null) return Unauthorized();

                Users user = _AuthService.GetOne((int)id);
                string token = _AuthenticateService.CreateToken(user);
                _AuthService.UpdateTokenDb(user.Id, token, user.RefreshToken, login.RememberMe);

                return Ok(new SuccessConnexion() { AccessToken = token, RefreshToken = user.RefreshToken, Nickname = user.NickName });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register register)
        {
            try
            {
                Users user = _AuthService.Register(register.ToUserAddress());
                string token = _AuthenticateService.CreateToken(user);
                _AuthService.UpdateTokenDb(user.Id, token, user.RefreshToken, false);
                _ = await _MailService.EmailData(user.Email, user.VerificationCode, user.Id, "Activation du compte Pintpoint.be", "Cliquez pour confirmer votre addresse email.", "http://localhost:4200/Pages/Auth/Verify/Email?code=");
                return Ok(new SuccessConnexion() { AccessToken = token, RefreshToken = user.RefreshToken, Nickname = user.NickName });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPost("Refresh")]
        public IActionResult Refresh(RefreshDTO tokenResponse)
        {
            try
            {
                List<Claim>? mesClaims = null;
                int id = 0;

                if (User.Claims.Count() != 0)
                {
                    mesClaims = User.Claims.ToList();
                    id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
                }
                else
                {
                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    JwtSecurityToken token = tokenHandler.ReadJwtToken(tokenResponse.AccessToken);
                    Claim? userIdClaim = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);

                    if (userIdClaim != null)
                    {
                        id = int.Parse(userIdClaim.Value);
                    }
                    else
                    {
                        // Handle the case where the claim is not found
                        return BadRequest(new { ErrorMessage = "Invalid token: User ID claim not found." });
                    }
                    mesClaims = token.Claims.ToList();
                }

                if (_AuthService.CheckRefresh(tokenResponse.AccessToken, tokenResponse.RefreshToken))
                {
                    string newAccessToken = _AuthenticateService.GenerateAccessTokenFromRefreshToken(mesClaims);

                    RefreshDTO response = new RefreshDTO()
                    {
                        AccessToken = newAccessToken,
                        RefreshToken = _AuthenticateService.GenerateRefreshToken()
                    };

                    _AuthService.UpdateRefreshTokenDb(id, response.AccessToken, response.RefreshToken);
                    return Ok(response);
                }
                else
                {
                    return BadRequest(new { ErrorMessage = "Tokens invalid" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("CheckExist")]
        public IActionResult CheckExist(string nickName = "", string email = "")
        {
            return Ok(_AuthService.CheckUserExists(nickName, email));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("UpdatePassword")]
        public IActionResult UpdatePassword(UpdatePassword updatePassword)
        {
            try
            {
                int userId = 0;
                string email = string.Empty;
                var userIdClaim = User.FindFirst(ClaimTypes.Sid);
                var emailClaim = User.FindFirst(ClaimTypes.Email);
                if (userIdClaim != null && emailClaim != null)
                {
                    userId = int.Parse(userIdClaim.Value);
                    email = emailClaim.Value;
                }

                if (_AuthService.UpdatePassword(userId, updatePassword.Password, updatePassword.OldPassword, email))
                {
                    return Ok(new { message = "Password updated" });
                }
                else
                {
                    return BadRequest(new { ErrorMessage = "Error updating password" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("DeleteUser")]
        public IActionResult Delete()
        {
            try
            {
                int userId = 0;
                string email = string.Empty;
                var userIdClaim = User.FindFirst(ClaimTypes.Sid);
                var emailClaim = User.FindFirst(ClaimTypes.Email);
                if (userIdClaim != null && emailClaim != null)
                {
                    userId = int.Parse(userIdClaim.Value);
                    email = emailClaim.Value;
                }
                if (_AuthService.DeleteUser(userId, email))
                {
                    return Ok(new { message = "User deleted" });
                }
                else
                {
                    return BadRequest(new { ErrorMessage = "Error deleting user" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPost("VerifyEmail")]
        public IActionResult VerifyEmail([FromBody] VerifyEmail verifyEmail)
        {
            try
            {
                if (string.IsNullOrEmpty(verifyEmail.code))
                {
                    return BadRequest(new { ErrorMessage = "Verification code is required" });
                }

                bool success = _AuthService.VerifyOne(verifyEmail.code, verifyEmail.id);

                if (success == false)
                {
                    return NotFound(new { ErrorMessage = "User not found or already verified" });
                }

                return Ok(new { message = "Email verified successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPut("UpdatePasswordByCode")]
        public IActionResult UpdatePasswordByCode([FromBody] PwdByCode pwdByCode)
        {
            try
            {
                bool success = _AuthService.updatePasswordBycode(pwdByCode.code, pwdByCode.id, pwdByCode.newPassword);
                if (success == false)
                {
                    return NotFound(new { ErrorMessage = "User not found or code is invalid" });
                }
                return Ok(new { message = "Password updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("GetPasswordCode")]
        public async Task<IActionResult> GetCode(string email)
        {
            try
            {
                int id = _AuthService.GetIdByMail(email);
                bool success = _AuthService.GeneratePwdCode(id);
                if (success == false)
                {
                    return NotFound(new { ErrorMessage = "User not found" });
                }
                Users user = _AuthService.GetOne(id);
                _ = await _MailService.EmailData(user.Email, user.PasswordResetCode, user.Id, "Changer votre mot de passe !", "Cliquez ici pour changer votre mot de passe.", "http://localhost:4200/Pages/Auth/Reset/Password?code=");
                return Ok(new { message = "Code Sent !" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }
    }
}
