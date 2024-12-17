using API_PintPoint.DTOs.Ratings;
using CORE_PintPoint.Abstraction.IService;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get([FromRoute] string type, [FromQuery] int idUser, [FromQuery] int offset = 0, [FromQuery] int limit = 20, [FromQuery] string order = "ASC")
        {
            return Ok(_ratingService.Get(offset, limit, order, type, idUser));
        }

        [HttpGet("Newest")]
        public IActionResult GetNewest([FromQuery] int idUser)
        {
            return Ok(_ratingService.GetNewest(idUser));
        }

        [HttpGet("Popular")]
        public IActionResult GetPopular([FromQuery] int idUser)
        {
            return Ok(_ratingService.GetPopular(idUser));
        }

        [HttpGet("Moyen/{idBeer}")]
        public IActionResult GetMoyenne([FromRoute] int idBeer)
        {
            return Ok(_ratingService.GetMoyenRate(idBeer));
        }

        [HttpPost]
        public IActionResult Post([FromBody] LikeRatingPost likeRatingPost)
        {
            return Ok(_ratingService.LikeUnlikeRating(likeRatingPost.likeStatus, likeRatingPost.idRating, likeRatingPost.idUser));
        }
    }
}
