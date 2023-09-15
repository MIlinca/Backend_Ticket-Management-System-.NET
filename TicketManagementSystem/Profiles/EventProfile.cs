using AutoMapper;
using System.Text.Json.Serialization;
using TicketManagementSystem.Models;
using TicketManagementSystem.Models.Dto;

namespace TicketManagementSystem.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>().ForMember(dest => dest.Venue, opt => opt.MapFrom(src => src.Venue != null ? src.Venue.Location : null))
                 .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType != null ? src.EventType.EventTypeName : null));

            CreateMap<EventDto, Event>()
              .ForMember(dest => dest.Venue, opt => opt.Ignore())
              ;

            CreateMap<Event, EventPatchDto>();
            CreateMap<EventPatchDto, Event>().ForMember(dest => dest.Venue, opt => opt.Ignore())
              .ForMember(dest => dest.EventType, opt => opt.Ignore())
              .ForMember(dest => dest.EventId, opt => opt.Ignore());
            

        }
    }
}
