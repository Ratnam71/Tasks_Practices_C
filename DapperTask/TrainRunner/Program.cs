using Microsoft.Extensions.Configuration;
using Runner;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using TrainEnquiry;

namespace TrainRunner
{
    class Program
    {
        private static IConfigurationRoot config;
        private static DateTime date;
        private static TimeSpan time;
        private static string place;

        static void Main(string[] args)
        {
            Console.WriteLine("enter date of the journey");
            DateTime inputtedDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("enter place of the journey");
            Console.ReadLine();


            Initialize();
            Get_all_should_return_train_results();
            Retrieve_All_TrainsList();
        }
        static void Get_all_should_return_train_results()
        {
            // arrange
            var repository = CreateRepository();

            // act
            var train = repository.GetAll();

            // assert
            Console.WriteLine($"Count: {train.Count}");
            Debug.Assert(train.Count >=1);
            train.Output();
        }

        static void Retrieve_All_TrainsList()
        {
            //arrange
            var repository = CreateRepository();

            //act
            var train = repository.Retrieve(date,time,place);

            //assert
            Console.WriteLine("***  train details ***");
            train.Output();
            Debug.Assert(train.train_id );
            Debug.Assert(train.train_name);
            Debug.Assert(train.Count >=1);
            Debug.Assert(train.train_number);
        }

        
        private static void Initialize()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            config = builder.Build();
        }
        private static ITrainRepository CreateRepository()
        {
            return new TrainRepository(config.GetConnectionString("Server = (LocalDb)\\MSSQLLocalDB; Database = Enquiry; Trusted_Connection = True; MultipleActiveResultSets = true"));
        }
    }
}
