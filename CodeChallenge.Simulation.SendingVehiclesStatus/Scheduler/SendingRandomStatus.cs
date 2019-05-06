using CodeChallenge.Simulation.MessageQueueing;
using CodeChallenge.Simulation.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Simulation.SendingVehiclesStatus.Scheduler
{

    public class SendingRandomStatus
    {
        //in memory vehicles 
        static List<Vehicle> vehicles = new List<Vehicle>()
            {
                new Vehicle(){ VIN="YS2R4X20005399401",Regnr="ABC123"},
                new Vehicle(){ VIN="VLUR4X20009093588",Regnr="DEF456"},
                new Vehicle(){ VIN="VLUR4X20009048066",Regnr="GHI789"},
                new Vehicle(){ VIN="YS2R4X20005388011",Regnr="JKL012"},
                new Vehicle(){ VIN="YS2R4X20005387949",Regnr="MNO345"},
                new Vehicle(){ VIN="VLUR4X20009048066",Regnr="PQR678"},
                new Vehicle(){ VIN="YS2R4X20005387055",Regnr="STU901"},
        };
        public void VehiclesPing()
        {
            for (int i = 0; i < vehicles.Count; i++)
            {
                Random rand = new Random();

                // this vehicle is Connected and will send a status to the Receiver 
                if (rand.Next(0, 2) != 0)
                {
                    vehicles[i].PingDate = DateTime.Now;
                    Vehicle connectedVehicle = vehicles[i];
                    string message = JsonConvert.SerializeObject(connectedVehicle);

                   new MessageProcessing().EnqueMessage(message);
                }
            }
        }
    }
}
