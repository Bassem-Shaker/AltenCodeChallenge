using CodeChallenge.VehiclesCore.Interfaces;
using CodeChallenge.VehiclesCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenge.VehiclesCore.UnitTest
{
    public class VehiclesDataRepositoryFake : IVehiclesDataRepository
    {
        private readonly List<Vehicle> vehicles;

        public VehiclesDataRepositoryFake()
        {
            vehicles = new List<Vehicle>()
            {
                new Vehicle(){CustomerID=1,CustomerName="Kalles Grustransporter AB",VIN="YS2R4X20005399401",Regnr="ABC123"},
                new Vehicle(){CustomerID=1,CustomerName="Kalles Grustransporter AB",VIN="VLUR4X20009093588",Regnr="DEF456"},
                new Vehicle(){CustomerID=1,CustomerName="Kalles Grustransporter AB",VIN="VLUR4X20009048066",Regnr="GHI789"},
                new Vehicle(){CustomerID=2,CustomerName="Johans Bulk AB",VIN="YS2R4X20005388011",Regnr="JKL012"},
                new Vehicle(){CustomerID=2,CustomerName="Johans Bulk AB",VIN="YS2R4X20005387949",Regnr="MNO345"},
                new Vehicle(){CustomerID=3,CustomerName="Haralds Värdetransporter AB",VIN="VLUR4X20009048066",Regnr="PQR678"},
                new Vehicle(){CustomerID=3,CustomerName="Haralds Värdetransporter AB",VIN="YS2R4X20005387055",Regnr="STU901"},

            };
        }

        public Vehicle Add(Vehicle newVehicle)
        {
            vehicles.Add(newVehicle);
            return newVehicle;
        }

        public void CloseConnection()
        {
            return;
        }

        public int Commit()
        {
            return 1;
        }

        public Vehicle Delete(int ID)
        {
            var deletedObj = Get(ID);
            if (deletedObj != null)
                vehicles.Remove(deletedObj);
            return deletedObj;
        }

        public IEnumerable<Vehicle> Find(int? customerID, bool? isConnected)
        {
            var result = vehicles.Where(m => (!customerID.HasValue || m.CustomerID == customerID));

            if (isConnected.HasValue && isConnected == true)
            {
                result = result.Where(m => m.LastPingTime.HasValue && m.LastPingTime >= DateTime.Now.AddMinutes(-1));
            }
            else if (isConnected.HasValue && isConnected == false)
            {
                result = result.Where(m => !m.LastPingTime.HasValue || m.LastPingTime < DateTime.Now.AddMinutes(-1));

            }
            return result;
        }

        public Vehicle find(string VIN, string Regnr)
        {
            return vehicles.FirstOrDefault(m => m.VIN == VIN && m.Regnr == Regnr);
        }

        public Vehicle Get(int ID)
        {
            return vehicles.FirstOrDefault(m => m.ID == ID);
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return vehicles;
        }

        public object OpenConnection()
        {
            return null;
        }

        public Vehicle Update(Vehicle updatedVehicle)
        {
            throw new NotImplementedException();
        }
    }
}
