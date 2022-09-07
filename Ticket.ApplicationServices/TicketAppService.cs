using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticket.DataAccess.Repositories;
using Ticket.ApplicationServices.Shared.Ticket.DTOs;
using Ticket.ApplicationServices.Journeys;
using Ticket.ApplicationServices.Passengers;
using ticket.Core;
using Microsoft.AspNetCore.Mvc;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Ticket.ApplicationServices
{
    public class TicketAppService : ITicketAppService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<int, ticket.Core.Ticket> _repository;
        private readonly IJourneysAppService _journeysAppService;
        private readonly IPassengersAppService _passengersAppService;

        public TicketAppService(IRepository<int, ticket.Core.Ticket> repository, IMapper mapper, IPassengersAppService passengersAppService, IJourneysAppService journeysAppService)
        {
            _mapper = mapper;
            _repository = repository;
            _passengersAppService = passengersAppService;
            _journeysAppService = journeysAppService;
        }

        public async Task<string> AddTicketAsync(TicketAddDto entity)
        {
            ticket.Core.Ticket ticket = _mapper.Map<ticket.Core.Ticket>(entity);
            var passenger = await _passengersAppService.GetPassenger(ticket.PassengerId);
            var journey = await _journeysAppService.GetJourney(ticket.JourneyId);
            /*if(passenger != null && journey != null)
            {
                await _repository.AddAsync(ticket);
                return ticket.Id;
            }*/
            if(passenger == null)
            {

                return "Passenger not found";
            }
            if(journey == null) {
                return "Journey not found";
            }
            else
            {
                await _repository.AddAsync(ticket);
                var id = ticket.Id.ToString();
                return id;
            }
            
        }

        public async Task DeleteTicketAsync(int ticketId)
        {
            await _repository.DeleteAsync(ticketId);
        }

        public async Task EditTicketAsync(int ticketId, TicketEditDto entity)
        {
            var ticket = await _repository.GetAsync(ticketId);
            var update = _mapper.Map<TicketEditDto, ticket.Core.Ticket>(entity, ticket);
            await _repository.UpdateAsync(update);
        }

        public async Task<TicketDto> GetTicketByIdAsync(int ticketId)
        {
            var ticket = await _repository.GetAsync(ticketId);
            var passenger = await _passengersAppService.GetPassenger(ticket.PassengerId);
            var journey = await _journeysAppService.GetJourney(ticket.JourneyId);
            TicketDto dto = _mapper.Map<TicketDto>(ticket);
            dto.Journey = journey;
            dto.Passenger = passenger;
            return dto;
        }

        public async Task<List<TicketDto>> GetTicketsAsync()
        {
            var tickets = await _repository.GetAll().ToListAsync();
            var list = _mapper.Map<List<TicketDto>>(tickets);
            return list;
        }
    }
}
