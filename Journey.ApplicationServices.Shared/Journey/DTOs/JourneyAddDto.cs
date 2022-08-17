using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.ApplicationServices.Shared.Journey.DTOs
{
    public class JourneyAddDto
    {
        [Required]
        public int DestinationId { get; set; }

        [Required]
        public int OriginId { get; set; }

        [Required]
        public DateTime Departure { get; set; }

        [Required]
        public DateTime Arrival { get; set; }
    }
}
