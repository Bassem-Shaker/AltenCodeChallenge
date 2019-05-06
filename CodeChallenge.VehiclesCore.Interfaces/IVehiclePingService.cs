using CodeChallenge.VehiclesCore.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.VehiclesCore.Interfaces
{
    public interface IVehiclePingService: IDataRepository
    {
        bool VehiclePingLogic(VehicleMetadata vehicleMetadata);
    }
}
