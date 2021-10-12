using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace TrainEnquiry
{
    public class TrainRepository : ITrainRepository
    {
        private IDbConnection db;
        private bool train_name;
        private int train_id;

        public TrainRepository (string connstring)
        {
            this.db = new SqlConnection(connstring);
        }
        public trains Add(trains train)
        {
            var sql =
                "insert into trains values(1, 'ratnachal_express', 12718),(2, 'Godavari_express', 12727),(3, 'janmabhoomi_express', 13456)";
            var id = this.db.Query<int>(sql, train).Single();
            train.train_id = id;
            return train;
        }

        public trains Find(int train_id)
        {
            return this.db.Query<trains>("SELECT * FROM trains WHERE train_id = @train_id", new { train_id }).SingleOrDefault();
        }

        public List<trains> GetAll()
        {
            return this.db.Query<trains>("SELECT *FROM trains").ToList();
        }

        public void Remove(int train_id)
        {
            this.db.Execute("DELETE FROM trains WHERE train_id = @train_id", new { train_id });
        }
        public trains GetFullTrains(int id)
        {
            var sql =
                "SELECT * FROM trains WHERE train_id = @train_id; " +
                "SELECT * FROM stations where station_id= @station_id";

            using (var multipleResults = this.db.QueryMultiple(sql, new { Id = id }))
            {
                var train = multipleResults.Read<trains>().SingleOrDefault();

                var station = multipleResults.Read<stations>().ToList();
                if (train != null && station != null)
                {
                    trains.stations.AddRange(station);
                }

                return trains;
            }
        }
        public List<trains> Retrieve(DateTime date, TimeSpan time, string place)
        {
            
            return this.db.Query("Select train_name from trains t, stations s, train_stops ts, train_schedule tsh where tsh.arrival >= (@time) and tsh.dept<= (@time) and s.station_name =(@station_name) and tsh.date = (@date) and s.station_id = ts.station_id and ts.sequence_id", date,time,train_name).ToList();
             
        }

        public trains Update(trains train)
        {
            throw new NotImplementedException();
        }
    }
}
