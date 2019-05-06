using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.VehiclesCore.Interfaces
{
    public interface IDataRepository
    {
        Object OpenConnection();
        void CloseConnection();
    }
}
