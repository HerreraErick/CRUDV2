using Microsoft.AspNetCore.Mvc;
using Ticket.ApplicationServices;
using Ticket.ApplicationServices.Shared.Ticket.DTOs;

namespace Ticket.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : Controller
    {
        private readonly ITicketAppService _ticketAppService;
        private readonly ILogger<TicketController> _logger;

        public TicketController(ITicketAppService ticketAppService, ILogger<TicketController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _ticketAppService = ticketAppService;
        }

        [HttpGet]
        [Route("GetAllPassengers")]
        public async Task<IEnumerable<TicketDto>> GetAllTickets()
        {
            List<TicketDto> tickets = await _ticketAppService.GetTicketsAsync();
            _logger.LogInformation("Total tickets retrieved: " + tickets?.Count);
            return tickets;
        }

        [HttpGet]
        [Route("GetTicketById/{id:int}")]
        public async Task<TicketDto> GetPassengerById([FromRoute] int id)
        {
            TicketDto ticket = await _ticketAppService.GetTicketByIdAsync(id);
            if (ticket != null)
            {
                _logger.LogInformation("Passenger found: " + ticket.Id);
                return ticket;
            }
            _logger.LogInformation("Passenger not found");
            return null;

        }

        [HttpPost]
        [Route("CreateTicket")]
        public async Task<IActionResult> CreateTicket(TicketAddDto entity)
        {
            if (entity != null)
            {
                await _ticketAppService.AddTicketAsync(entity);
                _logger.LogInformation("Ticket created" + entity);

                return Ok(entity);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("EditTicket/{id:int}")]
        public async Task<IActionResult> EditTicket([FromRoute] int id, TicketEditDto entity)
        {
            var ticket = await _ticketAppService.GetTicketByIdAsync(id);
            if (ticket != null)
            {
                await _ticketAppService.EditTicketAsync(id, entity);
                _logger.LogInformation("Ticket updated" + entity);

                return Ok(entity);
            }
            _logger.LogInformation("Ticket not found");
            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteTicket/{id:int}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] int id)
        {
            if(id != 0)
            {
                await _ticketAppService.DeleteTicketAsync(id);
                _logger.LogInformation("Ticket deleted");

                return Ok();
            }
            _logger.LogInformation("Ticket not found");
            return NotFound();
        }



    }
}
