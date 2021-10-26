using FinalTask_WebAPI.Train_Repositories;
using FinalTask_WebAPI.TSRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTask_WebAPI.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class StationController:ControllerBase
    {
       
        protected readonly ITrain_Repository _TrainRepository;
        public StationController(ITrain_Repository TrainRepository)
        {
            _TrainRepository = TrainRepository;
        }
        [HttpGet]
        [Route("FetchStations/{time}")]
        public async Task<IActionResult> GetAllStations_ParticularTrain_SpecifiedByTime(string time)
        {
            var stations = await _TrainRepository.GetAllStations_ParticularTrain_SpecifiedByTime(time);
            return Ok(stations);
        }
    }
}
