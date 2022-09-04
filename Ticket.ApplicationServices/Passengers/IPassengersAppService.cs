using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.ApplicationServices.Passengers
{
    public interface IPassengersAppService
    {
        Task<ticket.Core.Passengers.Passenger> GetPassenger(int id);
    }
}
