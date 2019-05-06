using System;
using System.Collections.Generic;

namespace CodeChallenge.Simulation.VehiclesStatus
{
    partial class Program
    {
        static List<VehicleData> Vehicles = new List<VehicleData>()
            {
                new VehicleData(){ VIN="YS2R4X20005399401",Regnr="ABC123"},
                new VehicleData(){ VIN="VLUR4X20009093588",Regnr="DEF456"},
                new VehicleData(){ VIN="VLUR4X20009048066",Regnr="GHI789"},
                new VehicleData(){ VIN="YS2R4X20005388011",Regnr="JKL012"},
                new VehicleData(){ VIN="YS2R4X20005387949",Regnr="MNO345"},
                new VehicleData(){ VIN="VLUR4X20009048066",Regnr="PQR678"},
                new VehicleData(){ VIN="YS2R4X20005387055",Regnr="STU901"},
            };
        static void Main(string[] args)
        {


            Console.WriteLine("Hello World!");
        }
    }
}
