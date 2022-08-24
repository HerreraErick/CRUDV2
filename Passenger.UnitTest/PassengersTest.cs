using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI.Common;
using passenger.Api.Controllers;
using passenger.ApplicationServices;
using Passengers.ApplicationServices.Shared.Passenger.DTOs;

namespace Passenger.UnitTest
{
    public class PassengersTest
    {
        private readonly PassengersController _controller;
        private readonly IPassengerAppService _service;
        private readonly ILogger<PassengersController> _logger;

        public PassengersTest()
        {
            _logger = A.Fake<ILogger<PassengersController>>();
            _service = A.Fake<IPassengerAppService>();
            _controller = new PassengersController(_service, _logger);
        }

        [Fact]
        public async Task AddPassenger()
        {
            //Arrange
            PassengerAddDto passenger = new PassengerAddDto()
            {
                FirstName = "Erick",
                LastName = "Herrera",
                Age = 24
            };

            //Act
            var result = await _controller.Create(passenger);


            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task EditPassenger()
        {
            //Arranger
            var id = 1;
            PassengerEditDto passenger = new PassengerEditDto()
            {
                FirstName = "Zuria",
                LastName = "Pat",
                Age = 26
            };

            //Act
            var updateData = await _controller.EditPassenger(id, passenger);

            //Assert
            Assert.True(updateData);
        }

        [Fact]
        public async Task GetPassenger()
        {
            //Arrange
            passenger.Core.Passenger p = new passenger.Core.Passenger()
            {
                Id = 2,
                FirstName = "Erick",
                LastName = "Herrera",
                Age = 24
            };

            //Act
            var result = await _controller.GetPassengerById(p.Id);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllPassengers()
        {
            //Arrage


            //Act
            var result = await _controller.GetAllPassengers();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeletePassenger()
        {
            // Arrange
            var id = 1;
            // Act
            var result = await _controller.DeletePassenger(id);
            // Assert
            Assert.True(result);
        }

    }
}