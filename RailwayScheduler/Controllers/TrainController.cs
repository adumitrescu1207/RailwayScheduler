using Microsoft.AspNetCore.Mvc;
using RailwayScheduler.Models;
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
        [HttpGet("GetAllTrains")]
        public IActionResult Get()
        {
            return Ok(_trainService.GetAll());
        }
        
        [HttpGet("GetById")]
        public IActionResult GetById(int id) {
            return Ok(_trainService.GetById(id));
        }
        
        [HttpGet("GetBySource")]
        public IActionResult GetBySource(string source)
        {
            return Ok(_trainService.GetBySource(source));
        }

        [HttpGet("GetByDestination")]
        public IActionResult GetByDestination(string destination) {
            return Ok(_trainService.GetByDestination(destination));
        }
        
        [HttpPost("AddTrain")]
        public IActionResult Post(Train train)
        {
            if (_trainService.GetById(train.Id) is not null)
                return BadRequest("Train already exists.");
            _trainService.Add(train);
            return Ok();
        }
        [HttpPut("UpdateTrain")]
        public IActionResult Put(Train train)
        {
            if (_trainService.GetById(train.Id) is null)
                return BadRequest("Train doesn't exist");
            _trainService.Update(train.Id, train);
            return Ok();
        }
        [HttpDelete("RemoveTrain")]
        public IActionResult Delete(int id)
        {
            if (_trainService.GetById(id) is not null)
                _trainService.Remove(id);
            return Ok();
        }

    }
}
