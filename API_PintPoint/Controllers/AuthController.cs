using API_PintPoint.DTOs.Auth;
using API_PintPoint.Mapper;
using API_PintPoint.Service;
using CORE_PintPoint.Abstraction.IService;
using Domain_PintPoint.Entities;
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
        public AuthController(IAuthService AuthService, AuthenticateService authenticateService)
        {
            _AuthService = AuthService;
            _AuthenticateService = authenticateService;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_AuthService.GetOne(id));
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
                _AuthService.UpdateTokenDb(user.Id, token, user.RefreshToken);

                return Ok(new SuccessConnexion() { AccessToken = token, RefreshToken = user.RefreshToken });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPost("Register")]
        public IActionResult Register(Register register)
        {
            try
            {
                Users user = _AuthService.Register(register.ToUserAddress());
                string token = _AuthenticateService.CreateToken(user);
                _AuthService.UpdateTokenDb(user.Id, token, user.RefreshToken);

                return Ok(new SuccessConnexion() { AccessToken = token, RefreshToken = user.RefreshToken });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
        }

        [HttpPost("refresh")]
        public IActionResult Refresh(SuccessConnexion tokenResponse)
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
                        // Handle the case where the claim is not found or cannot be parsed
                    }
                    mesClaims = token.Claims.ToList();
                }

                if (_AuthService.CheckRefresh(tokenResponse.AccessToken, tokenResponse.RefreshToken))
                {
                    string newAccessToken = _AuthenticateService.GenerateAccessTokenFromRefreshToken(mesClaims);

                    SuccessConnexion response = new SuccessConnexion()
                    {
                        AccessToken = newAccessToken,
                        RefreshToken = _AuthenticateService.GenerateRefreshToken()
                    };

                    _AuthService.UpdateTokenDb(id, newAccessToken, response.RefreshToken);
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Token invalid");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
        }
    }
}
