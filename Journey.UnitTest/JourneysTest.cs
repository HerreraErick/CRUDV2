using journey.Api.Controllers;
using journey.ApplicationServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using journey.DataAccess;
using Journey.ApplicationServices.Shared.Journey.DTOs;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;

namespace Journey.UnitTest
{
    public class JourneysTest
    {
        private readonly JourneysController _controller;
        private readonly IJourneyAppService _service;
        private readonly ILogger<JourneysController> _logger;

        public JourneysTest()
        {
            _logger = A.Fake<ILogger<JourneysController>>();
            _service = A.Fake<IJourneyAppService>();
            _controller = new JourneysController(_service, _logger);
        }

        [Fact]
        public async Task AddJourney()
        {
            //Arrange
            JourneyAddDto journey = new JourneyAddDto() 
            {
                DestinationId = 1, 
                OriginId = 1, 
                Departure = DateTime.Now, 
                Arrival = DateTime.Today 
            };

            //Act
            var result = await _controller.Create(journey);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task EditJourney()
        {
            //Arrange
            var id = 1;
            JourneyEditDto journey = new JourneyEditDto()
            {
                DestinationId = 5,
                OriginId = 5,
                Departure = DateTime.Now,
                Arrival = DateTime.Today
            };


            //Act
            var updatedData = await _controller.EditJourney(id, journey);

            //Assert
            Assert.True(updatedData);

            
        }

        [Fact]
        public async Task GetAllJourney()
        {
            //Arrage
            

            //Act
            var result = await _controller.GetAllJourneys();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetById()
        {
            //Arrange
            journey.Core.Journey j = new journey.Core.Journey()
            {
                Id = 1,
                DestinationId = 1,
                OriginId = 1,
                Departure = DateTime.Now,
                Arrival = DateTime.Today
            };

            //Act
            var result = await _controller.GetJourneysById(j.Id);

            //Assert
            Assert.True(result);

        }

        [Fact]
        public async Task HDeleteJourney()
        {
            // Arrange
            var id = 1;
            // Act
            var result = await _controller.DeleteJourney(id);
            // Assert
            Assert.True(result);
        }

    }
}