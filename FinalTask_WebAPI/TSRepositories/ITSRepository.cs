using FinalTask_WebAPI.TrainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTask_WebAPI.TSRepositories
{
    public interface ITSRepository
    {

        public void InsertDetails_ToTrainSchedule(Train_Schedule train);
        public void Delete_Train_Schedules(int train_number);
        Task<Train_Schedule> GetTrainSchedule_SpecifiedByDate(string date);

    }
}
