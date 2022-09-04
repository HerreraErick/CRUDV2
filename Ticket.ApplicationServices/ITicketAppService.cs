using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticket.DataAccess.Repositories;
using ticket.Core;
using Ticket.ApplicationServices.Shared.Ticket.DTOs;

namespace Ticket.ApplicationServices
{
    public interface ITicketAppService
    {
        Task<List<TicketDto>> GetTicketsAsync();

        Task<int> AddTicketAsync(TicketAddDto entity);

        Task DeleteTicketAsync(int ticketId);

        Task<TicketDto> GetTicketByIdAsync(int ticketId);

        Task EditTicketAsync(int ticketId, TicketEditDto entity);
    }
}
