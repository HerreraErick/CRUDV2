using AutoMapper;
using Journey.ApplicationServices.Shared.Journey.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace journey.ApplicationServices.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<journey.Core.Journey, JourneyDto>();
            CreateMap<JourneyAddDto, journey.Core.Journey>();
            CreateMap<JourneyEditDto, journey.Core.Journey>();
        }
    }
}
