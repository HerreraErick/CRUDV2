using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using journey.Core;
using passenger.Core;

namespace Ticket.ApplicationServices.Shared.Ticket.DTOs
{
    public class TicketAddDto
    {
        [Required]
        public Journey JourneyId { get; set; }

        [Required]
        public Passenger PassengerId { get; set; }

        [Required]
        public int Seat { get; set; }
    }
}
