using AutoMapper;
using passenger.Core;
using Passengers.ApplicationServices.Shared.Passenger.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passenger.ApplicationServices.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Passenger, PassengerDto>();
            CreateMap<PassengerAddDto, Passenger>();
            CreateMap<PassengerEditDto, Passenger>();
        }
    }
}
