using journey.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace journey.ApplicationServices
{
    public interface IJourneyAppService
    {
        Task<List<Journey>> GetJourneysAsync();

        Task<int> AddJourneyAsync(Journey journey);

        Task DeleteJourneyAsync(int journeyId);

        Task<Journey> GetJourneyAsync(int journeyId);

        Task EditJourneyAsync(Journey journey);
    }
}
