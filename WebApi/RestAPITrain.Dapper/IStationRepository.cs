using System;
using System.Collections.Generic;
using System.Text;
using RestAPITrain.Domain;
using System.Threading.Tasks;

namespace RestAPITrain.Dapper
{
    public interface IStationRepository
    {
        void Find(int Station_Id);
        List<Stations> GetAll();
        List<Stations> GetStationById(int Id);
        void Add(int Station_Id);
        void Remove(int Station_Id);
       

    }
}
