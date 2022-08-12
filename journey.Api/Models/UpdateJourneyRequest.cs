using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace journey.Api.Models
{
    public class UpdateJourneyRequest
    {
        public int DestinationId { get; set; }

        public int OriginId { get; set; }

        [BindProperty, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Departure { get; set; }

        [BindProperty, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Arrival { get; set; }
    }
}
