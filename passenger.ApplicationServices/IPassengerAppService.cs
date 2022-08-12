using passenger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passenger.ApplicationServices
{
    public interface IPassengerAppService
    {
        Task<List<Passenger>> GetPasengersAsync();

        Task<int> AddPassengerAsync(Passenger passenger);

        Task DeletePassengerAsync(int passengerId);

        Task<Passenger> GetPassengerByIdAsync(int passengerId);

        Task EditPassenger(Passenger passenger);
    }
}
