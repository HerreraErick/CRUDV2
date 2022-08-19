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

        public JourneyAppService()
        {
        }

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
            var journey = await GetJourneyAsync(journeyId);
            var update = _mapper.Map<JourneyEditDto, journey.Core.Journey>(entity, journey);
            await _repository.UpdateAsync(update);
        }

        public async Task<journey.Core.Journey> GetJourneyAsync(int journeyId)
        {
            return await _repository.GetAsync(journeyId);
        }

        public async Task<List<journey.Core.Journey>> GetJourneysAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }
    }
}
