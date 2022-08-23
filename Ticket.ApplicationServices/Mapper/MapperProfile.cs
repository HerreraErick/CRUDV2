using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.ApplicationServices.Shared.Ticket.DTOs;

namespace Ticket.ApplicationServices.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TicketAddDto, ticket.Core.Ticket>();
            CreateMap<TicketEditDto, ticket.Core.Ticket>();
        }
    }
}
