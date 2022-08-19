using passenger.Core;
using Passengers.ApplicationServices.Shared.Passenger.DTOs;
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

        Task<int> AddPassengerAsync(PassengerAddDto entity);

        Task DeletePassengerAsync(int passengerId);

        Task<Passenger> GetPassengerByIdAsync(int passengerId);

        Task EditPassenger(int passengerId, PassengerEditDto entity);
    }
}
