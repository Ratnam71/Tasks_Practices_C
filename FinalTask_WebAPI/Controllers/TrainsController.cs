using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalTask_WebAPI.Train_Repositories;
using FinalTask_WebAPI.TrainEntities;

namespace FinalTask_WebAPI.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class TrainsController: ControllerBase
    {
        
        protected readonly ITrain_Repository _TrainRepository;
        public TrainsController(ITrain_Repository TrainRepository)
        {
            _TrainRepository = TrainRepository;
        }
        [Route("InsertTrainDetails")]
        [HttpPost]
        public IActionResult InsertDetails_ToTrain([FromBody] TRAINS_DETAILS tr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
             _TrainRepository.InsertDetails_ToTrain(tr);
            return CreatedAtAction(nameof(InsertDetails_ToTrain), new { train_number = tr.train_number }, tr);

        }
        [HttpGet]
        [Route("FetchTrains/{station_name}/{time}")]
        public async Task<IActionResult> GetAllTrains_ByStationName_ANDTime(string station_name, string time)
        {
            var trains = await _TrainRepository.GetAllTrains_ByStationName_ANDTime(station_name, time);
            return Ok(trains);
        }

        
        [HttpDelete]
        [Route("DeleteTrainDetails")]
        public IActionResult Delete_Train_Details(int tn)
        {
            _TrainRepository.Delete_Train_Details(tn);
            return Ok();
        }
       


    }
}
