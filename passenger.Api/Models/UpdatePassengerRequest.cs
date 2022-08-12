using System.ComponentModel.DataAnnotations;

namespace passenger.Api.Models
{
    public class UpdatePassengerRequest
    {
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
