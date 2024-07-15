using Microsoft.AspNetCore.Mvc;
using RailwayScheduler.Services;

namespace RailwayScheduler.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainController: ControllerBase
    {
        private readonly TrainService _trainService;
        public TrainController(TrainService trainService)
        {
                _trainService = trainService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_trainService.GetAll());
        }
        /*
        [HttpGet]
        public IActionResult GetById(int id) {
            return Ok(_trainService.GetById(id));
        }

        [HttpGet]
        public IActionResult GetBySource(string source)
        {
            return Ok(_trainService.GetBySource(source));
        }

        [HttpGet]
        public IActionResult GetByDestination(string destination) {
            return Ok(_trainService.GetByDestination(destination));
        }
        */
    }
}
