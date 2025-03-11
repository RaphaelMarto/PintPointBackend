﻿using CORE_PintPoint.Abstraction.IService;
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

        [HttpGet("Profil-Info/{NickName}")]
        [ProducesResponseType<UserProfile>(200)]
        [ProducesResponseType(400)]
        public IActionResult GetProfileInfo([FromRoute] string NickName)
        {
            try
            {
                return Ok(_userService.GetUserProfile(NickName));
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
    }
}
