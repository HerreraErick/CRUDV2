using journey.Core;
using passenger.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.ApplicationServices.Shared.Ticket.DTOs
{
    public class TicketEditDto
    {
        public Journey JourneyId { get; set; }
                
        public Passenger PassengerId { get; set; }
                
        public int Seat { get; set; }
    }
}
