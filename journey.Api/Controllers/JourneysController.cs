
using journey.ApplicationServices;
using journey.Core;
using journey.DataAccess.Migrations;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Journey.ApplicationServices.Shared.Journey.DTOs;

namespace journey.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JourneysController : Controller
    {
        private readonly IJourneyAppService _journeyAppService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public JourneysController(IJourneyAppService journeyAppService, ILogger<JourneysController> logger, IMapper mapper)
        {
            _journeyAppService = journeyAppService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllJourneys")]
        public async Task<IActionResult> GetAllJourneys()
        {
            List<journey.Core.Journey> journey = await _journeyAppService.GetJourneysAsync();

            _logger.LogInformation("Total journeys retrieved: " + journey?.Count);

            return Ok(journey);
        }

        [HttpGet]
        [Route("GetJourneysById")]
        public async Task<IActionResult> GetJourneysById(int journeyId)
        {

            journey.Core.Journey journey = await _journeyAppService.GetJourneyAsync(journeyId);
            if(journey != null)
            {
                _logger.LogInformation("Journey found: " + journey.Id);
                return Ok(journey);
            }
            _logger.LogInformation("Journey not found");
            return NotFound();

        }

        [HttpPost]
        [Route("CreateJourney")]
        public async Task<IActionResult> Create(JourneyAddDto entity)
        {
            /*Journey journey = new Journey
            {
                Id = viewModel.Id,
                DestinationId = viewModel.DestinationId,
                OriginId = viewModel.OriginId,
                Departure = viewModel.Departure,
                Arrival = viewModel.Arrival
            };*/
            var j = _mapper.Map<Core.Journey>(entity);
            await _journeyAppService.AddJourneyAsync(j);
            _logger.LogInformation("Journey created" + entity);

            return Ok(entity);
        }

        [HttpPut]
        [Route("EditJourney/{id:int}")]
        public async Task<IActionResult> EditJourney([FromRoute] int id, JourneyEditDto entity)
        {
            var journey = await _journeyAppService.GetJourneyAsync(id);
            if (journey != null)
            {
                var j = _mapper.Map<JourneyEditDto, Core.Journey>(entity, journey);
                await _journeyAppService.EditJourneyAsync(j);
                _logger.LogInformation("Journey updated" + entity);

                return Ok(entity);
            }
            _logger.LogInformation("Journey not found");
            return NotFound();
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteJourney([FromRoute] int id)
        {
            await _journeyAppService.DeleteJourneyAsync(id);
            _logger.LogInformation("Journey deleted");

            return  Ok();
        }
    }
}
