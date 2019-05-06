using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.VehiclesCore.Models.Entities
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string VIN { get; set; }
        public string Regnr { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public DateTime? LastPingTime { get; set; }
    }
}
