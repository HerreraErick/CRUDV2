using journey.Api.Models;
using journey.ApplicationServices;
using journey.Core;
using journey.DataAccess.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace journey.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JourneysController : Controller
    {
        private readonly IJourneyAppService _journeyAppService;

        public JourneysController(IJourneyAppService journeyAppService)
        {
            _journeyAppService = journeyAppService;
        }

        [HttpGet]
        [Route("GetAllJourneys")]
        public async Task<IActionResult> GetAllJourneys()
        {
            List<Journey> journey = await _journeyAppService.GetJourneysAsync();

            JourneysListViewModel viewModel = new JourneysListViewModel();
            viewModel.Journeys = journey;

            return Ok(viewModel);
        }

        [HttpGet]
        [Route("GetJourneysById")]
        public async Task<IActionResult> GetJourneysById(int journeyId)
        {
            Journey journey = await _journeyAppService.GetJourneyAsync(journeyId);
            return Ok(journey);
        }

        [HttpPost]
        [Route("CreateJourney")]
        public async Task<IActionResult> Create(JourneyViewModel viewModel)
        {
            Journey journey = new Journey
            {
                Id = viewModel.Id,
                DestinationId = viewModel.DestinationId,
                OriginId = viewModel.OriginId,
                Departure = viewModel.Departure,
                Arrival = viewModel.Arrival
            };
            await _journeyAppService.AddJourneyAsync(journey);

            return Ok(journey);
        }

        [HttpPut]
        [Route("EditJourney/{id:int}")]
        public async Task<IActionResult> EditJourney([FromRoute] int id, UpdateJourneyRequest updateJourneyRequest)
        {
            var journey = await _journeyAppService.GetJourneyAsync(id);
            if (journey != null)
            {
                journey.DestinationId = updateJourneyRequest.DestinationId;
                journey.OriginId = updateJourneyRequest.OriginId;
                journey.Departure = updateJourneyRequest.Departure;
                journey.Arrival = updateJourneyRequest.Arrival;
               

                await _journeyAppService.EditJourneyAsync(journey);

                return Ok(journey);
            }
 
            return NotFound();
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteJourney([FromRoute] int id)
        {
            await _journeyAppService.DeleteJourneyAsync(id);

            return  Ok();
        }
    }
}
