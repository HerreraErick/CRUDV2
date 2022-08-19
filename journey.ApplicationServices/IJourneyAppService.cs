using journey.Core;
using Journey.ApplicationServices.Shared.Journey.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace journey.ApplicationServices
{
    public interface IJourneyAppService
    {
        Task<List<journey.Core.Journey>> GetJourneysAsync();

        Task<int> AddJourneyAsync(JourneyAddDto entity);

        Task DeleteJourneyAsync(int journeyId);

        Task<journey.Core.Journey> GetJourneyAsync(int journeyId);

        Task EditJourneyAsync(int journeyId, JourneyEditDto entity);
    }
}
