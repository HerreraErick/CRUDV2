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
            
            //var fakeJourney = A.Fake<JourneyAddDto>();
            A.CallTo(() => _service.AddJourneyAsync(journey));

            //Act
            var result = await _controller.Create(journey);

            //Assert
            Assert.True(result);
            //Assert.IsType<OkObjectResult>(result);
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
            A.CallTo(() => _service.EditJourneyAsync(id, journey)).Returns(Task.FromResult(journey));


            //Act
            var updatedData = await _controller.EditJourney(id, journey);

            //Assert
            Assert.True(updatedData);
        }

        [Fact]
        public async Task GetAllJourney()
        {
            //Arrage
            var journeys = new List<JourneyDto>() {new JourneyDto {Id = 1}};
            A.CallTo(() => _service.GetJourneysAsync()).Returns(Task.FromResult(journeys));

            //Act
            var result = await _controller.GetAllJourneys();

            var count1 = result.Count();
            var count2 = journeys.Count();

            //Assert
            Assert.Equal(count2, count1);
        }

        [Fact]
        public async Task GetById()
        {
            //Arrange
            JourneyDto j = new JourneyDto()
            {
                Id = 1,
                DestinationId = 1,
                OriginId = 1,
                Departure = DateTime.Now,
                Arrival = DateTime.Today
            };
            A.CallTo(() => _service.GetJourneyAsync(j.Id)).Returns(Task.FromResult(j));

            //Act
            var result = await _controller.GetJourneysById(j.Id);

            //Assert
            Assert.Equal(j.Id, result.Id);

        }

        [Fact]
        public async Task HDeleteJourney()
        {
            // Arrange
            var journey = new JourneyDto { Id = 1 } ;
            A.CallTo(() => _service.DeleteJourneyAsync(journey.Id)).Returns(Task.FromResult(journey));
            // Act
            var result = await _controller.DeleteJourney(journey.Id);
            // Assert
            Assert.True(result);
        }

    }
}