using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticket.Core;

namespace ticket.DataAccess
{
    public class TicketContext : DbContext
    {
        public TicketContext()
        {

        }

        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {

        }

        public virtual DbSet<ticket.Core.Ticket> Tickets { get; set; }

    }
}
