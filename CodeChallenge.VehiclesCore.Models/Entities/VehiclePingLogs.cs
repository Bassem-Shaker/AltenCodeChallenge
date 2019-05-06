using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.VehiclesCore.Models.Entities
{
    public class VehiclePingLog
    {
        public long ID { get; set; }
        public int VehicleID { get; set; }
        public DateTime PingDate { get; set; }
    }
}
