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
            A.CallTo(() => _service.AddPassengerAsync(passenger));

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
            A.CallTo(() => _service.EditPassenger(id, passenger)).Returns(Task.FromResult(passenger));

            //Act
            var updateData = await _controller.EditPassenger(id, passenger);

            //Assert
            Assert.True(updateData);
        }

        [Fact]
        public async Task GetPassenger()
        {
            //Arrange
            PassengerDto p = new PassengerDto()
            {
                Id = 1,
                FirstName = "Erick",
                LastName = "Herrera",
                Age = 24
            };
            A.CallTo(() => _service.GetPassengerByIdAsync(p.Id)).Returns(Task.FromResult(p));

            //Act
            var result = await _controller.GetPassengerById(p.Id);

            //Assert
            Assert.Equal(p.Id, result.Id);
        }

        [Fact]
        public async Task GetAllPassengers()
        {
            //Arrage
            var passengers = new List<PassengerDto>() { new PassengerDto { Id = 1 } };
            A.CallTo(() => _service.GetPasengersAsync()).Returns(Task.FromResult(passengers));

            //Act
            var result = await _controller.GetAllPassengers();

            var count1 = result.Count();
            var count2 = passengers.Count();

            //Assert
            Assert.Equal(count2, count1);
        }

        [Fact]
        public async Task HDeletePassenger()
        {
            // Arrange
            var passenger = new PassengerDto { Id = 1 };
            A.CallTo(() => _service.DeletePassengerAsync(passenger.Id)).Returns(Task.FromResult(passenger));

            // Act
            var result = await _controller.DeletePassenger(passenger.Id);
            // Assert
            Assert.True(result);
        }

    }
}