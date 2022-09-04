using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.ApplicationServices.Journeys
{
    public interface IJourneysAppService
    {
        Task<ticket.Core.Journeys.Journey> GetJourney(int id);
    }
}
