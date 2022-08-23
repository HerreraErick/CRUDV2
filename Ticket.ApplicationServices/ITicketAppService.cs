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
        Task<List<ticket.Core.Ticket>> GetTicketsAsync();

        Task<int> AddTicketAsync(TicketAddDto entity);

        Task DeleteTicketAsync(int ticketId);

        Task<ticket.Core.Ticket> GetTicketByIdAsync(int ticketId);

        Task EditTicketAsync(int ticketId, TicketEditDto entity);
    }
}
