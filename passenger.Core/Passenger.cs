using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passenger.Core
{
    public  class Passenger
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        public int Age { get; set; }

    }
}

/*
Ticket
[Key]
public int Id { get; set; }

public int JourneyId { get; set; }

public int PasengerId { get; set; }

public int Seat { get; set; }*/