using API_PintPoint.DTOs.Ratings;
using CORE_PintPoint.Abstraction.IService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_PintPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet("Type/{type}")]
        public IActionResult Get([FromRoute] string type, [FromQuery] int idBeer, [FromQuery] int offset = 0, [FromQuery] int limit = 20, [FromQuery] string order = "ASC")
        {
            try
            {
                int userId = 0;
                var userIdClaim = User.FindFirst(ClaimTypes.Sid);
                if (userIdClaim != null)
                {
                    userId = int.Parse(userIdClaim.Value);
                }

                return Ok(_ratingService.Get(offset, limit, order, type, userId, idBeer));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("Newest/{idBeer:int}")]
        public IActionResult GetNewest(int idBeer)
        {
            try
            {
                int userId = 0;
                var userIdClaim = User.FindFirst(ClaimTypes.Sid);
                if (userIdClaim != null)
                {
                    userId = int.Parse(userIdClaim.Value);
                }

                return Ok(_ratingService.GetNewest(userId, idBeer));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("Popular/{idBeer:int}")]
        public IActionResult GetPopular(int idBeer)
        {
            try
            {
                int userId = 0;
                var userIdClaim = User.FindFirst(ClaimTypes.Sid);
                if (userIdClaim != null)
                {
                    userId = int.Parse(userIdClaim.Value);
                }

                return Ok(_ratingService.GetPopular(userId, idBeer));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("Moyen/{idBeer}")]
        public IActionResult GetMoyenne([FromRoute] int idBeer)
        {
            return Ok(_ratingService.GetMoyenRate(idBeer));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult Post([FromBody] LikeRatingPost likeRatingPost)
        {
            try
            {
                int userId = 0;
                var userIdClaim = User.FindFirst(ClaimTypes.Sid);
                if (userIdClaim != null)
                {
                    userId = int.Parse(userIdClaim.Value);
                }

                return Ok(_ratingService.LikeUnlikeRating(likeRatingPost.likeStatus, likeRatingPost.idRating, userId));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }
    }
}
