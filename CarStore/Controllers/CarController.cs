using CarStore.Models;
using CarStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CarStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {

        private readonly ILogger<CarController> _logger;
        private readonly ICarService _carService;

        public CarController(ILogger<CarController> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var results = _carService.GetCar();
            return Ok(results);
        }

        [HttpPost]
        public IActionResult Post(Car request)
        {
            _carService.AddCar(request);
            return Ok();
        }

    }
}
