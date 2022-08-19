using journey.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace journey.DataAccess
{
    public class JourneyContext : DbContext
    {
        public JourneyContext()
        {
            
        }

        public JourneyContext(DbContextOptions<JourneyContext> options): base(options)
        {

        }

        public JourneyContext GetMemoryContext()
        {
            var options = new DbContextOptionsBuilder<JourneyContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            return new JourneyContext(options);
        }

        public virtual DbSet<Journey> Journeys { get; set; }

        
    }
}
