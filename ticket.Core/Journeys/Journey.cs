using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticket.Core.Journeys
{
    public class Journey
    {
        public int Id { get; set; }

        public int DestinationId { get; set; }

        public int OriginId { get; set; }

        public DateTime Departure { get; set; }

        public DateTime Arrival { get; set; }
    }
}
