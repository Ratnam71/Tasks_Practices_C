using Dapper;
using FinalTask_WebAPI.TrainEntities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTask_WebAPI.TSRepositories
{
    public class TSRepository : ITSRepository
    {
        protected readonly IConfiguration _Config;
        private IDbConnection db;
        public TSRepository(string connstring)
        {
            this.db = new SqlConnection(connstring);
        }
        public TSRepository(IConfiguration Config)
        {
            _Config = Config;
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_Config.GetConnectionString("DefaultConnection"));
            }
        }
        //insert train schedule details 
        public void InsertDetails_ToTrainSchedule(Train_Schedule train)
        {
            //return (List<Train_Schedule>)this.db.Query(@"INSERT INTO Train_Schedule(train_number,station_name,DaysTrain_Run) VALUES(@train_number,@station_name,@DaysTrain_Run)");
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO Train_Schedule(train_number,train_name,DaysTrain_Run,DateTrain_Run) 
                                       VALUES(@train_number,@train_name,@DaysTrain_Run,@DateTrain_Run)";
                    dbConnection.Execute(query, train);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Train_Schedule Details are already Entered", ex);
            }
        }
        //Delete train schedule details
        public void Delete_Train_Schedules(int train_number)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE *FROM Train_Schedule WHERE train_number =@train_number";
                    dbConnection.Execute(query, train_number);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //3.Return Trains schedules on a specified date.
        public async Task<Train_Schedule> GetTrainSchedule_SpecifiedByDate(string date)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = "SELECT train_number, train_name from TRAINS_DETAILS td, Train_Schedule ts where td.station_name = (@station_name) and td.station_name = ts.station_name and td.train_number = ts.train_number and td.DaysTrain_Run = (select to_char(date(@date), 'Day'))";
                    return await dbConnection.QueryFirstOrDefaultAsync<Train_Schedule>(query, new { DaysTrain_Run = date });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

    }
}
