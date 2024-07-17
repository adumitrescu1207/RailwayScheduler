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
        
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var train = _trainService.GetById(id);
            if (train == null)
                return BadRequest("Train with this ID not found.");
            return Ok(train);
        }

        [HttpGet("GetSourceByTime/{source}")]
        public IActionResult GetSourceAlphabetically(string source)
        {
            var trains = _trainService.GetSourceByTime(source);
            if (trains == null || !trains.Any())
                return BadRequest("Trains from this source not found.");
            return Ok(trains);
        }

        [HttpGet("GetDestinationByTime/{destination}")]
        public IActionResult GetDestinationAlphabetically(string destination)
        {
            var trains = _trainService.GetDestinationByTime(destination);
            if (trains == null || !trains.Any())
                return BadRequest("Trains to this destination not found.");
            return Ok(trains);
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
            if (_trainService.GetById(id) is null)
                return BadRequest("Train doesn't exist");
            _trainService.Remove(id);
            return Ok();
        }

    }
}
