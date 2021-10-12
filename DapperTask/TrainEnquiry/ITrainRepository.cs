using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEnquiry
{
    public interface ITrainRepository
    {
        trains Find(int train_id);
        List<trains> GetAll();
        trains Add(trains train);
        trains Update(trains train);
        trains GetFullTrains(int id);
        void Remove(int train_id);
        List<trains> Retrieve(DateTime date, TimeSpan time, string place);
        
    }
}
