using FinalTask_WebAPI.TrainEntities;
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
    public class TSController:ControllerBase
    {
        protected readonly ITSRepository _TSRepository;
        public TSController(ITSRepository TrainRepository)
        {
            _TSRepository = TrainRepository;
        }
        [HttpPost]
        [Route("InsertTrainSchdeules")]
        [HttpPost]
        public IActionResult InsertDetails_ToTrainSchedule([FromBody] Train_Schedule ts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _TSRepository.InsertDetails_ToTrainSchedule(ts);
            return CreatedAtAction(nameof(InsertDetails_ToTrainSchedule), new { train_number = ts.train_number }, ts);

        }
        [HttpGet]
        [Route("FetchTrain_Schedule/{date}")]
        public async Task<IActionResult> GetTrainSchedule_SpecifiedByDate(string date)
        {
            var stat = await _TSRepository.GetTrainSchedule_SpecifiedByDate(date);
            return Ok(stat);
        }
        [HttpDelete]
        [Route("DeleteTrain_ScheduleDetails")]
        public IActionResult Delete_Train_Schedules(int ts)
        {
            _TSRepository.Delete_Train_Schedules(ts);
            return Ok();
        }
    }
}
