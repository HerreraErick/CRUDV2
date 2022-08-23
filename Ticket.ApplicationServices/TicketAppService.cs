using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticket.DataAccess.Repositories;
using Ticket.ApplicationServices.Shared.Ticket.DTOs;

namespace Ticket.ApplicationServices
{
    public class TicketAppService : ITicketAppService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<int, ticket.Core.Ticket> _repository;

        public TicketAppService(IRepository<int, ticket.Core.Ticket> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> AddTicketAsync(TicketAddDto entity)
        {
            var ticket = _mapper.Map<ticket.Core.Ticket>(entity);
            await _repository.AddAsync(ticket);
            return ticket.Id;
        }

        public async Task DeleteTicketAsync(int ticketId)
        {
            await _repository.DeleteAsync(ticketId);
        }

        public async Task EditTicketAsync(int ticketId, TicketEditDto entity)
        {
            var ticket = await GetTicketByIdAsync(ticketId);
            var update = _mapper.Map<TicketEditDto, ticket.Core.Ticket>(entity, ticket);
            await _repository.UpdateAsync(update);
        }

        public async Task<ticket.Core.Ticket> GetTicketByIdAsync(int ticketId)
        {
            return await _repository.GetAsync(ticketId);
        }

        public async Task<List<ticket.Core.Ticket>> GetTicketsAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }
    }
}
