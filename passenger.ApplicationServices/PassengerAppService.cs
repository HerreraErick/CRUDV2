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
            var passenger = await _repository.GetAsync(passengerId);
            var update = _mapper.Map<PassengerEditDto, Passenger>(entity, passenger);
            await _repository.UpdateAsync(update);
        }

        public async Task<List<PassengerDto>> GetPasengersAsync()
        {
            var passengers = await _repository.GetAll().ToListAsync();
            var list = _mapper.Map<List<PassengerDto>>(passengers);
            return list;
        }

        public async Task<PassengerDto> GetPassengerByIdAsync(int passengerId)
        {
            var entity = await _repository.GetAsync(passengerId);
            var passenger = _mapper.Map<PassengerDto>(entity);
            return passenger;
        }
    }
}
