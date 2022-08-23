using journey.ApplicationServices;
using passenger.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.ApplicationServices.Shared.Ticket.DTOs;

namespace ticket.DataAccess.Repositories
{
    public class TicketsRepository : Repository<int, ticket.Core.Ticket>
    {
        private readonly PassengerAppService _passengerAppService;
        private readonly JourneyAppService _journeyAppService;
        public TicketsRepository(TicketContext context, PassengerAppService passengerAppService, JourneyAppService journeyAppService) : base(context)
        {
            _passengerAppService = passengerAppService;
            _journeyAppService = journeyAppService;
        }

        /*public override async Task<ticket.Core.Ticket> AddAsync(ticket.Core.Ticket entity)
        {
            if (entity == null) { 
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null"); 
            }
            try
            {
                var journey = await _journeyAppService.GetJourneyAsync(entity.JourneyId);
                entity.JourneyId = 0;
                await Context.Tickets.AddAsync(entity);
                
                
            }
            catch (Exception ex)
            {
                var mensaje = "Error message: " + ex.Message;
                //throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
                if (ex.InnerException != null)
                {
                    mensaje = mensaje + "Inner exception: " + ex.InnerException.Message;
                }


                throw new Exception($"{nameof(entity)} could not be saved: {mensaje}");
            }
        }*/

    }
}
