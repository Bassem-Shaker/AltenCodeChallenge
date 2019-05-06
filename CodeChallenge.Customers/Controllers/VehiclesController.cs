using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Customers.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        [HttpPost]
        [Route("Get")]

        public IActionResult Get(FilterVehicle filterVehicle)
        {
            List<Vehicle> Vehicles = new List<Vehicle>()
            {
                new Vehicle(){ VehicleID=1, CustomerID=1,VIN="YS2R4X20005399401",Regnr="ABC123",ConnectionType=1},
                new Vehicle(){ VehicleID=2, CustomerID=1,VIN="VLUR4X20009093588",Regnr="DEF456",ConnectionType=0},
                new Vehicle(){ VehicleID=3, CustomerID=1,VIN="VLUR4X20009048066",Regnr="GHI789",ConnectionType=1},
                new Vehicle(){ VehicleID=4, CustomerID=2,VIN="YS2R4X20005388011",Regnr="JKL012",ConnectionType=1},
                new Vehicle(){ VehicleID=5, CustomerID=2,VIN="YS2R4X20005387949",Regnr="MNO345",ConnectionType=1},
                new Vehicle(){ VehicleID=6, CustomerID=3,VIN="VLUR4X20009048066",Regnr="PQR678",ConnectionType=1},
                new Vehicle(){ VehicleID=7, CustomerID=3,VIN="YS2R4X20005387055",Regnr="STU901",ConnectionType=1},
            };

            if (filterVehicle!=null)
            {
                Vehicles = Vehicles.Where(m => (filterVehicle.CustomerID<0 || m.CustomerID == filterVehicle.CustomerID) 
                                        && (filterVehicle.IsConnected<0 || m.ConnectionType == filterVehicle.IsConnected)).ToList();
            }
            return Ok(Vehicles);
        }
    }
    public class FilterVehicle
    {
        public int CustomerID { get; set; }
        public int IsConnected { get; set; }

    }
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string VIN { get; set; }
        public string Regnr { get; set; }
        public int CustomerID { get; set; }

        public int ConnectionType { get; set; }
    }
}