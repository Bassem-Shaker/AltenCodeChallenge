using CodeChallenge.VehiclesCore.Controllers;
using CodeChallenge.VehiclesCore.Interfaces;
using CodeChallenge.VehiclesCore.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeChallenge.VehiclesCore.UnitTest
{


    public class VehiclesControllerTest
    {
        IVehiclesDataRepository vehiclesDataRepository;
        VehiclesController vehiclesController;
        FilterVehicle filterVehicle;

        public VehiclesControllerTest()
        {
            vehiclesDataRepository = new VehiclesDataRepositoryFake();
            vehiclesController = new VehiclesController(vehiclesDataRepository);
        }
        [Fact]
        public void Getall_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            filterVehicle = new FilterVehicle()
            {
                CustomerID = -1,
                IsConnected = -1
            };
            // Act
            var okResult = vehiclesController.GetAll(filterVehicle);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

    }
}
