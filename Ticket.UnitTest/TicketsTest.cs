using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI.Common;
using Passengers.ApplicationServices.Shared.Passenger.DTOs;
using Ticket.Api.Controllers;
using Ticket.ApplicationServices;
using Ticket.ApplicationServices.Journeys;
using Ticket.ApplicationServices.Passengers;
using Ticket.ApplicationServices.Shared.Ticket.DTOs;

namespace Ticket.UnitTest
{
    public class TicketsTest
    {
        private readonly TicketController _controller;
        private readonly ITicketAppService _service;
        private readonly ILogger<TicketController> _logger;
        private readonly IJourneysAppService _journeyService;
        private readonly IPassengersAppService _passengerService;

        public TicketsTest()
        {
            _service = A.Fake<ITicketAppService>();
            _logger = A.Fake<ILogger<TicketController>>();
            _controller = new TicketController(_service, _logger);
        }

        [Fact]
        public async Task AddTicket()
        {
            //Arrange
            TicketAddDto ticket = new TicketAddDto()
            {
                JourneyId = A.Fake<ticket.Core.Journeys.Journey>(),
                PassengerId = A.Fake<ticket.Core.Passengers.Passenger>(),
                Seat = 5
            };
            A.CallTo(() => _service.AddTicketAsync(ticket));

            //Act
            var result =  await _controller.CreateTicket(ticket);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task EditTicket()
        {
            //Arrange
            var id = 1;
            TicketEditDto ticket = new TicketEditDto()
            {
                JourneyId = A.Fake<ticket.Core.Journeys.Journey>(),
                PassengerId = A.Fake<ticket.Core.Passengers.Passenger>(),
                Seat = 2
            };
            A.CallTo(() => _service.EditTicketAsync(id,ticket)).Returns(Task.FromResult(ticket));

            //Act
            var update = await _controller.EditTicket(id, ticket);

            //Assert
            Assert.True(update);
        }

        [Fact]
        public async Task GetTicket()
        {
            //Arrange
            TicketDto ticket = new TicketDto()
            {
                Id = 1,
                Journey = A.Fake<ticket.Core.Journeys.Journey>(),
                Passenger = A.Fake<ticket.Core.Passengers.Passenger>(),
                Seat = 2
            };
            A.CallTo(() => _service.GetTicketByIdAsync(ticket.Id)).Returns(ticket);

            //Act
            var result = await _controller.GetTicketById(ticket.Id);

            //Assert
            Assert.Equal(ticket.Id, result.Id);
        }

        [Fact]
        public async Task GetAllTickets()
        {
            //Arrange
            var ticket = new List<TicketDto>() { new TicketDto { Id = 1 } };
            A.CallTo(() => _service.GetTicketsAsync()).Returns(Task.FromResult(ticket));

            //Act
            var result = await _controller.GetAllTickets();

            var count1 = result.Count();
            var count2 = ticket.Count();

            //Assert
            Assert.Equal(count1, count2);
        }

        [Fact]
        public async Task HDeleteTicket()
        {
            //Arrange
            var ticket = new TicketDto { Id = 1 };
            A.CallTo(() => _service.DeleteTicketAsync(ticket.Id)).Returns(Task.FromResult(ticket));

            //Act
            var result = await _controller.DeleteTicket(ticket.Id);

            //Assert
            Assert.True(result);
        }

    }
}