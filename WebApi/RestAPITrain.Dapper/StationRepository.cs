using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Linq;
using Microsoft.Extensions.Configuration;
using RestAPITrain.Domain;

namespace RestAPITrain.Dapper
{
    public class StationRepository : IStationRepository
    {
        protected readonly IConfiguration _config;
        private IDbConnection db;
        public StationRepository(IConfiguration config)
        {
            _config = config;

        }
        //create an IDBConnection object called Connection to into our database connection
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultDbConnection"));

            }
        }

        public void Add(int Station_Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO Stations(Station_Name,Station_Id) VALUES(@Station_Name,@Station_Id)";
                    dbConnection.Execute(query);

                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<Stations> GetStationsById(int Id)
        {
            return this.db.Query<Stations>("SELECT *FROM Stations WHERE Station_Id=@Station_Id").ToList();
        }
        public void  Find(int Station_Id)
        {
            throw new NotImplementedException();
        }

        public List<Stations> GetAll()
        {
            return this.db.Query<Stations>("SELECT *FROM Stations").ToList();
        }

        public void Remove(int Station_Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM Stations WHERE Station_Id =@Station_Id";
                    dbConnection.Execute(query);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(int Station_Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE Stations SET Station_Name=@Station_Name,Station_Id =@Station_Id";
                    dbConnection.Execute(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        
    }
}
