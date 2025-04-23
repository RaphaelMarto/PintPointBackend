using API_PintPoint.Mapper;
using CORE_PintPoint.Abstraction.IService;
using Domain_PintPoint.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_PintPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Top3/{NickName}")]
        public IActionResult GetTop3([FromRoute] string NickName)
        {
            try 
            { 
                return Ok(_userService.getTop3(NickName)); 
            }
            catch (Exception ex) 
            { 
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("Profil-Picture/{NickName}")]
        [ProducesResponseType<UserPP>(200)]
        [ProducesResponseType(400)]
        public IActionResult GetUserPP([FromRoute] string NickName)
        {
            try
            {
                return Ok(_userService.GetUserPP(NickName));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("Recent-Rating/{NickName}")]
        public IActionResult GetRecentRating([FromRoute] string NickName)
        {
            try
            {
                return Ok(_userService.GetRecentRating(NickName));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("User-Ratings/{NickName}")]
        public IActionResult GetUserRating([FromRoute] string NickName, [FromQuery] string type, [FromQuery] int offset = 0, [FromQuery] int limit = 20, [FromQuery] string order = "ASC")
        {
            try
            {
                return Ok(_userService.RatingBeerUser(offset, limit, order, type, NickName));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("Profile/{NickName}")]
        public IActionResult GetUserProfile([FromRoute] string NickName)
        {
            try
            {
                return Ok(_userService.GetUserProfile(NickName)?.ToUserProfile());
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPut("Profile/{NickName}")]
        public IActionResult UpdateUserProfile([FromRoute] string NickName, [FromBody] UserUpdate userUpdate)
        {
            try
            {
                if (_userService.UpdateUserProfile(userUpdate, NickName))
                    return Ok(true);
                else
                    return BadRequest(new { ErrorMessage = "Error while updating the profile" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPut("Address")]
        public IActionResult UpdateUserAddress([FromBody] UserAddress userAddress)
        {
            try
            {
                if (_userService.UpdateUserAddress(userAddress))
                    return Ok(true);
                else
                    return BadRequest(new { ErrorMessage = "Error while updating the address" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }
    }
}
