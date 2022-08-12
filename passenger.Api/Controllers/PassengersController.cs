using Microsoft.AspNetCore.Mvc;
using passenger.Api.Models;
using passenger.ApplicationServices;
using passenger.Core;

namespace passenger.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PassengersController : Controller
    {
        private readonly IPassengerAppService _passengerAppService;

        public PassengersController(IPassengerAppService passengerAppService)
        {
            _passengerAppService = passengerAppService;
        }

        [HttpGet]
        [Route("GetAllPassengers")]
        public async Task<IActionResult> GetAllPassengers()
        {
            List<Passenger> passengers = await _passengerAppService.GetPasengersAsync();

            return Ok(passengers);
        }

        [HttpGet]
        [Route("GetPassengerById/{id:int}")]
        public async Task<IActionResult> GetPassengerById([FromRoute] int id)
        {
            Passenger passenger = await _passengerAppService.GetPassengerByIdAsync(id);
            return Ok(passenger);
        }

        [HttpPost]
        [Route("CreatePassenger")]
        public async Task<IActionResult> Create(PassengerViewModel viewModel)
        {
            Passenger passenger = new Passenger
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Age = viewModel.Age,
            };
            await _passengerAppService.AddPassengerAsync(passenger);

            return Ok(passenger);
        }

        [HttpPut]
        [Route("EditPassenger/{id:int}")]
        public async Task<IActionResult> EditPassenger([FromRoute]int id, UpdatePassengerRequest updatePassengerRequest)
        {
            var passenger = await _passengerAppService.GetPassengerByIdAsync(id);
            if(passenger != null)
            {
                passenger.FirstName = updatePassengerRequest.FirstName;
                passenger.LastName = updatePassengerRequest.LastName;
                passenger.Age = updatePassengerRequest.Age;

                await _passengerAppService.EditPassenger(passenger);

                return Ok(passenger);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeletePassenger([FromRoute]int id)
        {
            await _passengerAppService.DeletePassengerAsync(id);

            return Ok();
        }
    }
}
