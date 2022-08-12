using journey.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        protected string connectionString = "server=localhost;port=3306;database=journey;user=root;password=12345678;CharSet=utf8;SslMode=none;Pooling=false;AllowPublicKeyRetrieval=True";
        public JourneyContext()
        {

        }

        public JourneyContext(DbContextOptions<JourneyContext> options): base(options)
        {

        }

        public virtual DbSet<Journey> Journeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
