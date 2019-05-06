using CodeChallenge.Simulation.Models;
using CodeChallenge.VehiclesCore.Interfaces;
using CodeChallenge.VehiclesCore.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.VehiclesCore.BussinessLayer
{
    public class VehiclePingService : IVehiclePingService
    {
        public bool VehiclePingLogic(VehicleMetadata vehicleMetadata)
        {
            Vehicle vehicle = vehiclesDataRepository.find(vehicleMetadata.VIN, vehicleMetadata.Regnr);

            //Add new entry in the log table
            vehiclePingLogsDataRepository.Add(new VehiclePingLog()
            {
                PingDate = DateTime.Now,
                VehicleID = vehicle.ID
            });
            vehiclePingLogsDataRepository.Commit();

            //Update Vehicle record with the last ping time.
            vehicle.LastPingTime = DateTime.Now;

            vehiclesDataRepository.Update(vehicle);
            vehiclesDataRepository.Commit();
            return true;
        }
    }
}
