using CodeChallenge.VehiclesCore.Interfaces;
using CodeChallenge.VehiclesCore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenge.VehiclesCore.EntityFramework
{
    public class VehiclePingLogsDataService : EntityFrameworkRepository,IVehiclePingLogsDataRepository
    {

        public VehiclePingLogsDataService()
        {
        }
        public VehiclePingLog Add(VehiclePingLog newVehicleLog)
        {
            dbConnection.VehiclePingLogs.Add(newVehicleLog);
            return newVehicleLog;
        }

        public int Commit()
        {
            return dbConnection.SaveChanges();
        }

        public VehiclePingLog Delete(int ID)
        {
            var removedEntity = Get(ID);
            if (removedEntity != null)
                dbConnection.VehiclePingLogs.Remove(removedEntity);
            return removedEntity;
        }

        public VehiclePingLog Get(int ID)
        {
            return dbConnection.VehiclePingLogs.FirstOrDefault(m => m.ID == ID);
        }

        public IEnumerable<VehiclePingLog> GetAll()
        {
            return dbConnection.VehiclePingLogs.AsEnumerable();
        }

        public VehiclePingLog Update(VehiclePingLog updatedVehiclePingLog)
        {
            var entity = dbConnection.VehiclePingLogs.Attach(updatedVehiclePingLog);
            entity.State = EntityState.Modified;
            return updatedVehiclePingLog;
        }
    }
}
