using CORE_PintPoint.Abstraction.IRepo;
using CORE_PintPoint.Abstraction.IService;
using Microsoft.AspNetCore.Mvc;

namespace API_PintPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _countriesService;
        private readonly ICountriesRepo _countriesRepo;

        public CountriesController(ICountriesService countriesService, ICountriesRepo countriesRepo)
        {
            _countriesService = countriesService;
            _countriesRepo = countriesRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_countriesService.GetAll());
        }
    }
}
