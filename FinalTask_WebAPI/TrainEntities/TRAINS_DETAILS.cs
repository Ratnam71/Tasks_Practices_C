using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FinalTask_WebAPI.TrainEntities
{
    public class TRAINS_DETAILS
    {
        public int train_number { get; set; }
        public string train_name { get; set; }
        public string station_name { get; set; }
        public string arrival_time { get; set; }
        public string departure_time { get; set; }
    }
}
