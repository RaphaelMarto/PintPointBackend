using API_PintPoint.Mapper;
using CORE_PintPoint.Abstraction.IService;
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_beersService.GetAll().Select(e => e.ToDTO()).ToList());
        }
    }
}
