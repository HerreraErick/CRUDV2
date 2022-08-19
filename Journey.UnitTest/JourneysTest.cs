using journey.Api.Controllers;
using journey.ApplicationServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using journey.DataAccess;
using Journey.ApplicationServices.Shared.Journey.DTOs;
using FakeItEasy;
using FluentAssertions;

namespace Journey.UnitTest
{
    public class JourneysTest
    {
        private readonly JourneysController _controller;
        private readonly IJourneyAppService _service;
        private readonly ILogger<JourneysController> _logger;
        //private readonly JourneyContext _context;

        public JourneysTest()
        {
            _logger = A.Fake<ILogger<JourneysController>>();
            _service = A.Fake<IJourneyAppService>();
            _controller = new JourneysController(_service, _logger);
            //_context = context;
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
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task EditJourney()
        {
            //Arrange
            var id = 2;
            var existente = _controller.GetJourneysById(id);
            var okResult = existente.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<JourneyEditDto>().Subject;

            var journey = new JourneyEditDto();
            journey.DestinationId = 2;
            journey.OriginId = result.OriginId;
            journey.Departure = result.Departure;
            journey.Arrival = result.Arrival;

            //Act
            var updatedData = await _controller.EditJourney(id, journey);

            //Assert
            Assert.IsType<OkObjectResult>(updatedData);
        }

        [Fact]
        public async Task GetAllJourney()
        {
            //Arrage
            

            //Act
            var result = await _controller.GetAllJourneys();

            //Assert
            Assert.IsType<OkObjectResult>(result);
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
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task DeleteJourney()
        {
            // Arrange
            var id = 3;
            // Act
            var result = await _controller.DeleteJourney(id);
            // Assert
            Assert.IsType<OkResult>(result);
        }

    }
}