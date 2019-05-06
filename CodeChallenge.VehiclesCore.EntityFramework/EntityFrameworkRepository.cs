using CodeChallenge.VehiclesCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.VehiclesCore.EntityFramework
{
    public class EntityFrameworkRepository : IDataRepository
    {
        private VehiclesDatabaseContext dbContext;
       
        
        /// <summary>
        /// Database Context
        /// </summary>
        public VehiclesDatabaseContext dbConnection
        {
            get { return dbContext; }
        }

        public object OpenConnection()
        {
            dbContext = new VehiclesDatabaseContext();
            return dbContext;
        }
        public void CloseConnection()
        {
            dbContext = null;
        }
    }
}
