using CORE_PintPoint.Abstraction.IService;
using Microsoft.AspNetCore.Mvc;

namespace API_PintPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_countriesService.GetAll());
        }

        [HttpGet("Cities")]
        public IActionResult GetCities()
        {
            return Ok(_countriesService.GetCities());
        }
    }
}
