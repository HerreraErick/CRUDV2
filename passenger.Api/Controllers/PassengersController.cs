using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using passenger.Api.Models;
using passenger.ApplicationServices;
using passenger.Core;
using passenger.DataAccess.Migrations;
using Passengers.ApplicationServices.Shared.Passenger.DTOs;

namespace passenger.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PassengersController : Controller
    {
        private readonly IPassengerAppService _passengerAppService;
        private readonly ILogger<PassengersController> _logger;

        public PassengersController(IPassengerAppService passengerAppService, ILogger<PassengersController> logger)
        {
            _passengerAppService = passengerAppService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Route("GetAllPassengers")]
        public async Task<IActionResult> GetAllPassengers()
        {
            List<Passenger> passengers = await _passengerAppService.GetPasengersAsync();
            _logger.LogInformation("Total passengers retrieved: " + passengers?.Count);

            return Ok(passengers);
        }

        [HttpGet]
        [Route("GetPassengerById/{id:int}")]
        public async Task<IActionResult> GetPassengerById([FromRoute] int id)
        {
            Passenger passenger = await _passengerAppService.GetPassengerByIdAsync(id);
            if(passenger != null)
            {
                _logger.LogInformation("Passenger found: " + passenger.FirstName);
                return Ok(passenger);
            }
            _logger.LogInformation("Passenger not found");
            return NotFound();
            
        }

        [HttpPost]
        [Route("CreatePassenger")]
        public async Task<IActionResult> Create(PassengerAddDto entity)
        {
            if(entity != null)
            {
                await _passengerAppService.AddPassengerAsync(entity);
                _logger.LogInformation("Passenger created" + entity);

                return Ok(entity);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("EditPassenger/{id:int}")]
        public async Task<IActionResult> EditPassenger([FromRoute]int id, PassengerEditDto entity)
        {
            var passenger = await _passengerAppService.GetPassengerByIdAsync(id);
            if(passenger != null)
            {
                await _passengerAppService.EditPassenger(id, entity);
                _logger.LogInformation("Passenger updated" + entity);

                return Ok(entity);
            }
            _logger.LogInformation("Passenger not found");
            return NotFound();
            
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeletePassenger([FromRoute]int id)
        {
            await _passengerAppService.DeletePassengerAsync(id);
            _logger.LogInformation("Passenger deleted");

            return Ok();
        }
    }
}
