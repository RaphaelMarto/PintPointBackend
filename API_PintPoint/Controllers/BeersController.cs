using API_PintPoint.DTOs.Beers;
using API_PintPoint.Mapper;
using CORE_PintPoint.Abstraction.IService;
using CORE_PintPoint.Entities;
using Domain_PintPoint.Entities;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(_beersService.GetOne(id).ToDTO());
        }
    }
}
