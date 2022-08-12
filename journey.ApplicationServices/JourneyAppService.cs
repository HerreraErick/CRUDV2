using journey.Core;
using journey.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace journey.ApplicationServices
{
    public class JourneyAppService : IJourneyAppService
    {
        private readonly IRepository<int, Journey> _repository;

        public JourneyAppService(IRepository<int, Journey> repository)
        {
            _repository = repository;
        }

        public async Task<int> AddJourneyAsync(Journey journey)
        {
            await _repository.AddAsync(journey);
            return journey.Id;
        }

        public async Task DeleteJourneyAsync(int journeyId)
        {
            await _repository.DeleteAsync(journeyId);
        }

        public async Task EditJourneyAsync(Journey journey)
        {
            await _repository.UpdateAsync(journey);
        }

        public async Task<Journey> GetJourneyAsync(int journeyId)
        {
            return await _repository.GetAsync(journeyId);
        }

        public async Task<List<Journey>> GetJourneysAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }
    }
}
