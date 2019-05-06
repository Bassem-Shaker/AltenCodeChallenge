using CodeChallenge.VehiclesCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.VehiclesCore.Interfaces
{
    public interface IVehiclePingLogsDataRepository: IDataRepository
    {
        IEnumerable<VehiclePingLog> GetAll();
        VehiclePingLog Get(int ID);
        VehiclePingLog Add(VehiclePingLog newVehiclePingLog);
        VehiclePingLog Delete(int ID);
        VehiclePingLog Update(VehiclePingLog updatedVehiclePingLog);
        int Commit();
    }
}
