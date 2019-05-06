using CodeChallenge.VehiclesCore.Models.Entities;
using System;
using System.Collections.Generic;

namespace CodeChallenge.VehiclesCore.Interfaces
{
    public interface IVehiclesDataRepository: IDataRepository
    {
        IEnumerable<Vehicle> GetAll();
        IEnumerable<Vehicle> Find(int? customerID,bool? isConnected);
        Vehicle Get(int ID);
        Vehicle find(string VIN, string Regnr);
        Vehicle Add(Vehicle newVehicle);
        Vehicle Delete(int ID);
        Vehicle Update(Vehicle updatedVehicle);
        int Commit();
    }
}
