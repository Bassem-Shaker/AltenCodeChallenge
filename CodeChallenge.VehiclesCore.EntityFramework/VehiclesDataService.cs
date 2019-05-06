using CodeChallenge.VehiclesCore.Interfaces;
using CodeChallenge.VehiclesCore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenge.VehiclesCore.EntityFramework
{
    public class VehiclesDataService : EntityFrameworkRepository, IVehiclesDataRepository
    {

        public VehiclesDataService()
        {
        }
        public Vehicle Add(Vehicle newVehicle)
        {
            dbConnection.Vehicles.Add(newVehicle);
            return newVehicle;
        }

        public int Commit()
        {
            return dbConnection.SaveChanges();
        }

        public Vehicle Delete(int ID)
        {
            var removedEntity = Get(ID);
            if (removedEntity != null)
                dbConnection.Vehicles.Remove(removedEntity);
            return removedEntity;
        }

        public IEnumerable<Vehicle> Find(int? customerID, bool? isConnected)
        {
            var result = dbConnection.Vehicles.Where(m => (!customerID.HasValue || m.CustomerID == customerID));

            if (isConnected.HasValue && isConnected == true)
            {
                result = result.Where(m => m.LastPingTime.HasValue && m.LastPingTime >= DateTime.Now.AddMinutes(-1));
            }
            else if (isConnected.HasValue && isConnected == false)
            {
                result = result.Where(m => !m.LastPingTime.HasValue || m.LastPingTime < DateTime.Now.AddMinutes(-1));

            }
            return result.AsEnumerable();
        }

        public Vehicle find(string VIN, string Regnr)
        {
            return dbConnection.Vehicles.FirstOrDefault(m => m.VIN == VIN && m.Regnr == Regnr);
        }

        public Vehicle Get(int ID)
        {
            return dbConnection.Vehicles.FirstOrDefault(m => m.ID == ID);
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return dbConnection.Vehicles.AsEnumerable();
        }

        public Vehicle Update(Vehicle updatedVehicle)
        {
            var entity = dbConnection.Vehicles.Attach(updatedVehicle);
            entity.State = EntityState.Modified;
            return updatedVehicle;
        }
    }
}
