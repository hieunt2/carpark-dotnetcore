using CarPark.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarPark.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CarParkController : Controller
    {
        private readonly ICarParkService _carParkService;

        public CarParkController(ICarParkService carParkService)
        {
            _carParkService = carParkService;
        }

        [HttpGet]
        [Route("CarParkAvailability")]
        public async Task<IActionResult> GetCarParkAvailability() => Ok(await _carParkService.GetCarParkAvailabilities());        
    }
}
