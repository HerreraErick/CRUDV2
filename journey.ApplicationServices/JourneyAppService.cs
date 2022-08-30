using journey.Core;
using journey.DataAccess.Repositories;
using Journey.ApplicationServices.Shared.Journey.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using journey.DataAccess.Migrations;

namespace journey.ApplicationServices
{
    public class JourneyAppService : IJourneyAppService
    {
        private readonly IRepository<int, journey.Core.Journey> _repository;
        private readonly IMapper _mapper;



        public JourneyAppService(IRepository<int, journey.Core.Journey> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddJourneyAsync(JourneyAddDto entity)
        {
            var journey = _mapper.Map<Core.Journey>(entity);
            await _repository.AddAsync(journey);
            return journey.Id;
        }

        public async Task DeleteJourneyAsync(int journeyId)
        {
            await _repository.DeleteAsync(journeyId);
        }

        public async Task EditJourneyAsync(int journeyId, JourneyEditDto entity)
        {
            var journey = await _repository.GetAsync(journeyId);
            var update = _mapper.Map<JourneyEditDto, journey.Core.Journey>(entity, journey);
            await _repository.UpdateAsync(update);
        }

        public async Task<JourneyDto> GetJourneyAsync(int journeyId)
        {
            var getjourney = await _repository.GetAsync(journeyId);
            var journey = _mapper.Map<JourneyDto>(getjourney);
            return journey;
        }

        public async Task<List<JourneyDto>> GetJourneysAsync()
        {
            var journeys = await _repository.GetAll().ToListAsync();
            var list = _mapper.Map<List<JourneyDto>>(journeys);
            return list;
        }
    }
}
