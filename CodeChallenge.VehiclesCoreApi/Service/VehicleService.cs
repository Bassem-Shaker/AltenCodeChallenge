using CodeChallenge.VehiclesCore.EntityFramework;
using CodeChallenge.VehiclesCore.Interfaces;
using CodeChallenge.VehiclesCore.Models.DataModels;
using CodeChallenge.VehiclesCore.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.VehiclesCoreApi.Service
{
    public class VehicleService
    {
        internal bool VehiclePingLogic(VehicleMetadata vehicleMetadata)
        {

            VehiclesDataService vehiclesDataService = new VehiclesDataService();
            VehiclePingLogsDataService vehiclePingLogsDataService = new VehiclePingLogsDataService();
            vehiclesDataService.OpenConnection();
            vehiclePingLogsDataService.OpenConnection();
            Vehicle vehicle = vehiclesDataService.find(vehicleMetadata.VIN, vehicleMetadata.Regnr);
            //Add new entry in the log table
            vehiclePingLogsDataService.Add(new VehiclePingLog()
            {
                PingDate = DateTime.Now,
                VehicleID = vehicle.ID
            });
            vehiclePingLogsDataService.Commit();
            vehiclePingLogsDataService.CloseConnection();

            //Update Vehicle record with the last ping time.
            vehicle.LastPingTime = DateTime.Now;

            vehiclesDataService.Update(vehicle);
            vehiclesDataService.Commit();
            vehiclesDataService.CloseConnection();
            return true;
        }
    }
}
