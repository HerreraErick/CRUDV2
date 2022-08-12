using Microsoft.EntityFrameworkCore;
using passenger.Core;
using passenger.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passenger.ApplicationServices
{
    public class PassengerAppService : IPassengerAppService
    {
        private readonly IRepository<int, Passenger> _repository;

        public PassengerAppService(IRepository<int, Passenger> repository)
        {
            _repository = repository;
        }
        
        public async Task<int> AddPassengerAsync(Passenger passenger)
        {
            await _repository.AddAsync(passenger);
            return passenger.Id;
        }

        public async Task DeletePassengerAsync(int passengerId)
        {
            await _repository.DeleteAsync(passengerId);
        }

        public async Task EditPassenger(Passenger passenger)
        {
            await _repository.UpdateAsync(passenger);
        }

        public async Task<List<Passenger>> GetPasengersAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<Passenger> GetPassengerByIdAsync(int passengerId)
        {
            return await _repository.GetAsync(passengerId);
        }
    }
}
