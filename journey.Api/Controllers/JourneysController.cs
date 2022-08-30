
using journey.ApplicationServices;
using journey.Core;
using journey.DataAccess.Migrations;
using Microsoft.AspNetCore.Mvc;
using Journey.ApplicationServices.Shared.Journey.DTOs;

namespace journey.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JourneysController : Controller
    {
        private readonly IJourneyAppService _journeyAppService;
        private readonly ILogger _logger;

        public JourneysController(IJourneyAppService journeyAppService, ILogger<JourneysController> logger)
        {
            _journeyAppService = journeyAppService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Route("GetAllJourneys")]
        public async Task<IEnumerable<JourneyDto>> GetAllJourneys()
        {
            List<JourneyDto> journeys = await _journeyAppService.GetJourneysAsync();

            _logger.LogInformation("Total journeys retrieved: " + journeys?.Count);

            return journeys;
        }

        [HttpGet]
        [Route("GetJourneysById")]
        public async Task<JourneyDto> GetJourneysById(int journeyId)
        {

            JourneyDto journey = await _journeyAppService.GetJourneyAsync(journeyId);
            _logger.LogInformation("Journey found: " + journey.Id);
            return journey;


        }

        [HttpPost]
        [Route("CreateJourney")]
        public async Task<bool> Create(JourneyAddDto entity)
        {
            if (entity != null)
            {
                await _journeyAppService.AddJourneyAsync(entity);
                _logger.LogInformation("Journey created" + entity);

                return true;
            }
            return false;
        }

        [HttpPut]
        [Route("EditJourney/{id:int}")]
        public async Task<bool> EditJourney([FromRoute] int id, JourneyEditDto entity)
        {
            var journey = await _journeyAppService.GetJourneyAsync(id);
            if (journey != null)
            {
                await _journeyAppService.EditJourneyAsync(id, entity);
                _logger.LogInformation("Journey updated" + entity);

                return true;
            }
            _logger.LogInformation("Journey not found");
            return false;
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<bool> DeleteJourney([FromRoute] int id)
        {
            await _journeyAppService.DeleteJourneyAsync(id);
            _logger.LogInformation("Journey deleted");

            return true;
        }
    }
}
