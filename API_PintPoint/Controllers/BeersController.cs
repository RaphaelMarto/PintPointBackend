using API_PintPoint.DTOs.Beers;
using API_PintPoint.Mapper;
using CORE_PintPoint.Abstraction.IService;
using CORE_PintPoint.Entities;
using Domain_PintPoint.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_PintPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly IBeersService _beersService;
        public BeersController(IBeersService beersService)
        {
            _beersService = beersService;
        }

        [HttpGet("Type/{type}")]
        public IActionResult Get([FromRoute] string type, [FromQuery] string search = "", [FromQuery] int offset = 0, [FromQuery] int limit = 20, [FromQuery] string order = "ASC")
        {
            OffsetResult<BeersWithNames> result = _beersService.GetAll(offset, limit, order, type, search);
            return Ok(
                    new OffsetResult<BeersDTO>()
                    {
                        Total = result.Total,
                        Results = result.Results.Select(e => e.ToDTO()).ToList()
                    }
                );
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOne([FromRoute] int id)
        {
            try
            {
                int userId = 0;
                var userIdClaim = User.FindFirst(ClaimTypes.Sid);
                if (userIdClaim != null)
                {
                    userId = int.Parse(userIdClaim.Value);
                }

                return Ok(_beersService.GetOne(id, userId).ToCompleteDTO());
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult post([FromBody] BeerPost beerPost)
        {
            return Ok(_beersService.Post(beerPost.ToDomain()));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public IActionResult Update([FromBody] BeerPut beerPut)
        {
            return Ok(_beersService.Update(beerPut.ToDomain()));
        }
    }
}
