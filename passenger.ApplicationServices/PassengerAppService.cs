using Microsoft.EntityFrameworkCore;
using passenger.Core;
using passenger.DataAccess.Repositories;
using Passengers.ApplicationServices.Shared.Passenger.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace passenger.ApplicationServices
{
    public class PassengerAppService : IPassengerAppService
    {
        private readonly IRepository<int, Passenger> _repository;
        private readonly IMapper _mapper;

        public PassengerAppService(IRepository<int, Passenger> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<int> AddPassengerAsync(PassengerAddDto entity)
        {
            var passenger = _mapper.Map<Passenger>(entity);
            await _repository.AddAsync(passenger);
            return passenger.Id;
        }

        public async Task DeletePassengerAsync(int passengerId)
        {
            await _repository.DeleteAsync(passengerId);
        }

        public async Task EditPassenger(int passengerId, PassengerEditDto entity)
        {
            var passenger = await GetPassengerByIdAsync(passengerId);
            var update = _mapper.Map<PassengerEditDto, Passenger>(entity, passenger);
            await _repository.UpdateAsync(update);
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
