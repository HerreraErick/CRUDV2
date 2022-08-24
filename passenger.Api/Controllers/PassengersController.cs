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
        public async Task<bool> GetAllPassengers()
        {
            List<Passenger> passengers = await _passengerAppService.GetPasengersAsync();
            _logger.LogInformation("Total passengers retrieved: " + passengers?.Count);

            return true;
        }

        [HttpGet]
        [Route("GetPassengerById/{id:int}")]
        public async Task<bool> GetPassengerById([FromRoute] int id)
        {
            Passenger passenger = await _passengerAppService.GetPassengerByIdAsync(id);
            if(passenger != null)
            {
                _logger.LogInformation("Passenger found: " + passenger.FirstName);
                return true;
            }
            _logger.LogInformation("Passenger not found");
            return false;
            
        }

        [HttpPost]
        [Route("CreatePassenger")]
        public async Task<bool> Create(PassengerAddDto entity)
        {
            if(entity != null)
            {
                await _passengerAppService.AddPassengerAsync(entity);
                _logger.LogInformation("Passenger created" + entity);

                return true;
            }
            return false;
        }

        [HttpPut]
        [Route("EditPassenger/{id:int}")]
        public async Task<bool> EditPassenger([FromRoute]int id, PassengerEditDto entity)
        {
            var passenger = await _passengerAppService.GetPassengerByIdAsync(id);
            if(passenger != null)
            {
                await _passengerAppService.EditPassenger(id, entity);
                _logger.LogInformation("Passenger updated" + entity);

                return true;
            }
            _logger.LogInformation("Passenger not found");
            return false;
            
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<bool> DeletePassenger([FromRoute]int id)
        {
            await _passengerAppService.DeletePassengerAsync(id);
            _logger.LogInformation("Passenger deleted");

            return true;
        }
    }
}
