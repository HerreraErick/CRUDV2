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
            CreateMap<ticket.Core.Ticket, TicketDto>().ReverseMap()
                .ForMember(d => d.JourneyId, o => o.MapFrom(s => s.Journey))
                .ForMember(d => d.PassengerId, o => o.MapFrom(s => s.Passenger));

            CreateMap<int, ticket.Core.Ticket> ()
                .ForMember(dest => dest.JourneyId, opts => opts.MapFrom(src => src));

            CreateMap<int, ticket.Core.Ticket>()
                .ForMember(dest => dest.PassengerId, opts => opts.MapFrom(src => src));

            CreateMap<TicketAddDto, ticket.Core.Ticket>()
                .ForMember(d => d.JourneyId, o => o.MapFrom(s => s.JourneyId))
                .ForMember(d => d.PassengerId, o => o.MapFrom(s => s.PassengerId));

            CreateMap<TicketEditDto, ticket.Core.Ticket>()
                .ForMember(d => d.JourneyId, o => o.MapFrom(s => s.JourneyId))
                .ForMember(d => d.PassengerId, o => o.MapFrom(s => s.PassengerId));

        }
    }
}
