using Microsoft.EntityFrameworkCore;
using passenger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passenger.DataAccess
{
    public  class PassengerContext : DbContext
    {
        public PassengerContext()
        {

        }

        public PassengerContext(DbContextOptions<PassengerContext> options): base(options) { }

        public virtual DbSet<Passenger> Passengers { get; set; }
    }
}
