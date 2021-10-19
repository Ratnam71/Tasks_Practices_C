using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPITrain.Domain
{
    public class Trains
    {
        public int Train_Id { get; set; }
        public string Train_Name { get; set; }

        public TimeSpan Arrival { get; set; }

        public TimeSpan Departure { get; set; }

    }
}
