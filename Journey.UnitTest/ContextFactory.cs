using journey.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.UnitTest
{
    public class ContextFactory
    {
        public void Configurations(IServiceCollection services)
        {
            services.AddDbContext<JourneyContext>(options =>
        options.UseInMemoryDatabase(databaseName: "Journey"));
        }

    }
}
