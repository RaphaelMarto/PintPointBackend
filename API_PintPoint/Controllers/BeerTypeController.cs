using CORE_PintPoint.Abstraction.IService;
using Microsoft.AspNetCore.Mvc;

namespace API_PintPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerTypeController : ControllerBase
    {
        private readonly IBeerTypeService _beerTypeService;
        public BeerTypeController(IBeerTypeService beerTypeService)
        {
            _beerTypeService = beerTypeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_beerTypeService.GetAll());
        }
    }
}
