using API_PintPoint.DTOs.Breweries;
using API_PintPoint.Mapper;
using CORE_PintPoint.Abstraction.IService;
using Microsoft.AspNetCore.Mvc;

namespace API_PintPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweriesController : ControllerBase
    {
        private readonly IBreweriesService _breweriesService;

        public BreweriesController(IBreweriesService breweriesService)
        {
            _breweriesService = breweriesService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_breweriesService.GetAll().Select(b => b.ToDTO()).ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_breweriesService.GetOne(id).ToCompleteDTO());
        }

        [HttpPost]
        public IActionResult post(BreweriesPost breweriesPost)
        {
            return Ok(_breweriesService.Post(breweriesPost.ToDomain()));
        }
    }
}
