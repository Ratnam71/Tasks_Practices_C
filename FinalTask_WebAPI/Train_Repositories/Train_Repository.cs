using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using FinalTask_WebAPI.TrainEntities;
using System.Threading.Tasks;

namespace FinalTask_WebAPI.Train_Repositories
{
    public class Train_Repository: ITrain_Repository
    {
        protected readonly IConfiguration _Config;
        private IDbConnection db;
        public Train_Repository(string connstring)
        {
            this.db = new SqlConnection(connstring);
        }
        public Train_Repository(IConfiguration Config)
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


        //1.Return Trains List that pass through a particular station with a particular time specified.
        public async Task<TRAINS_DETAILS> GetAllTrains_ByStationName_ANDTime(string station_name, string time)
        {
            
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = "SELECT train_number, train_name from TRAINS_DETAILS td, Trains_Schedule ts where td.station_name =(@station_name) and arrival_time = @arrival_time and td.station_name = ts.station_name and td.train_number = ts.train_number";
                    return await dbConnection.QueryFirstOrDefaultAsync<TRAINS_DETAILS>(query, new { train_name= station_name ,arrival_time = time});
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //2.Return Stations List that a particular train passes on a particular time specified
        public async Task<TRAINS_DETAILS> GetAllStations_ParticularTrain_SpecifiedByTime(string time)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = "SELECT station_name from TRAINS_DETAILS td where td.train_number = (@train_number) and arrival_time =@arrival_time";
                    return await dbConnection.QueryFirstOrDefaultAsync<TRAINS_DETAILS>(query, new { arrival_time = time});
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //insert trains and stations details
        public void InsertDetails_ToTrain(TRAINS_DETAILS train)
        {
            //return (List<TRAINS_DETAILS>)this.db.Query(@"INSERT INTO TRAINS_DETAILS(train_number, train_name,station_name,arrival_time,departure_time) VALUES(@train_number, @train_name,@station_name,@arrival_time,@departure_time)");
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO TRAINS_DETAILS(train_number, train_name,station_name,arrival_time,departure_time)
                                    VALUES(@train_number, @train_name,@station_name,@arrival_time,@departure_time)";
                    dbConnection.Execute(query, train);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Train Details are already Entered", ex);
            }
        }


        
        public void Delete_Train_Details(int train_number)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM TRAINS_DETAILS WHERE train_number=@train_number";
                    dbConnection.Execute(query, train_number);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        


    }
}
