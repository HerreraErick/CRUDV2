using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.ApplicationServices.Shared.Passenger.DTOs
{
    public class PassengerDto
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
