
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
            if (entity != null)
            {
                await _journeyAppService.AddJourneyAsync(entity);
                _logger.LogInformation("Journey created" + entity);

                return Ok(entity);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("EditJourney/{id:int}")]
        public async Task<IActionResult> EditJourney([FromRoute] int id, JourneyEditDto entity)
        {
            var journey = await _journeyAppService.GetJourneyAsync(id);
            if (journey != null)
            {
                await _journeyAppService.EditJourneyAsync(id, entity);
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

            return Ok();
        }
    }
}
