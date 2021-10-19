using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPITrain.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StationController : ControllerBase
    {
        protected readonly IStationRepository _stationRepository;
        public StationController(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Add([FromBody] StationController station)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _stationRepository.AddDeveloper(station);
            return CreatedAtAction(nameof(GetStationById), new { Station_Id = station.Station_Id }, station);

        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Remove(int Station_Id)
        {
            _stationRepository.Remove(Station_Id);
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update([FromBody] StationController station)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _stationRepository.Update(station);
            return Ok();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<Stations> GetAll(StationController station)
        {
            var stations =  _stationRepository.GetAll();
            return Ok(stations);
        }




    }
}
