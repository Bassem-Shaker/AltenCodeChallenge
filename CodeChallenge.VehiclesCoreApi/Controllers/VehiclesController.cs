using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.VehiclesCore.EntityFramework;
using CodeChallenge.VehiclesCore.Interfaces;
using CodeChallenge.VehiclesCore.Models.DataModels;
using CodeChallenge.VehiclesCore.Models.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.VehiclesCore.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesDataRepository vehiclesDataRepository;

        public VehiclesController(IVehiclesDataRepository vehiclesDataRepository)
        {
            this.vehiclesDataRepository = vehiclesDataRepository;
        }
        [HttpPost]
        [Route("Get")]

        public IActionResult GetAll(FilterVehicle filterVehicle)
        {
            IEnumerable<Vehicle> result;
            vehiclesDataRepository.OpenConnection();
            if (filterVehicle == null)
            {
                result = vehiclesDataRepository.GetAll();
            }
            else
            {
                int? filterCutomerID = filterVehicle.CustomerID < 0 ? (int?)null : filterVehicle.CustomerID;
                bool? filterIsconnected = filterVehicle.IsConnected < 0 ? (bool?)null : (filterVehicle.IsConnected > 0 ? true : false);
                result = vehiclesDataRepository.Find(filterCutomerID, filterIsconnected);
            }

            //TODO: Use automapper
            IEnumerable<VehicleViewModel> vehicleViewModelList = result.Select(x => new VehicleViewModel
            {
                CustomerID = x.CustomerID,
                CustomerName = x.CustomerName,
                ID = x.ID,
                VIN = x.VIN,
                LastPingTime = x.LastPingTime,
                Regnr = x.Regnr,
                Isconnected = (x.LastPingTime.HasValue&& x.LastPingTime >= DateTime.Now.AddMinutes(-1))
            });
            vehiclesDataRepository.CloseConnection();
            return Ok(vehicleViewModelList);
            
        }
    }
}