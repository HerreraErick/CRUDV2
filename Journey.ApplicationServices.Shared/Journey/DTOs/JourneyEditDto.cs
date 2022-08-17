using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.ApplicationServices.Shared.Journey.DTOs
{
    public class JourneyEditDto
    {
        [Required]
        public int DestinationId { get; set; }

        
        public int OriginId { get; set; }

        [Required]
        public DateTime Departure { get; set; }

        [Required]
        public DateTime Arrival { get; set; }
    }
}
