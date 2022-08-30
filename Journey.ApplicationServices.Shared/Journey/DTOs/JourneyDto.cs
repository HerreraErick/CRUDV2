using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.ApplicationServices.Shared.Journey.DTOs
{
    public class JourneyDto
    {
        public int Id { get; set; }

        public int DestinationId { get; set; }

        public int OriginId { get; set; }

        //[BindProperty, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Departure { get; set; }

        //[BindProperty, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Arrival { get; set; }
    }
}
