using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FinalTask_WebAPI.TrainEntities;

namespace FinalTask_WebAPI.Train_Repositories
{
    public interface ITrain_Repository
    {
        
        //Task<TRAINS_DETAILS> ADDEditStation(Train_Schedule station);
        //Task<Train_Schedule> DeleteStation(int id);
        Task<TRAINS_DETAILS> GetAllTrains_ByStationName_ANDTime(string station_name,string time);
        Task<TRAINS_DETAILS> GetAllStations_ParticularTrain_SpecifiedByTime(string time);
        
        public void InsertDetails_ToTrain(TRAINS_DETAILS train);
        
        public void Delete_Train_Details(int train_number);
       


    }
}
