using ticket.Core.Journeys;
using ticket.Core.Passengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.ApplicationServices.Shared.Ticket.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }

        public Journey Journey { get; set; }

        public Passenger Passenger { get; set; }

        public int Seat { get; set; }
    }
}
