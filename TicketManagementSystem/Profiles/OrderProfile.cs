using TicketManagementSystem.Models.Dto;
using TicketManagementSystem.Models;
using AutoMapper;

namespace TicketManagementSystem.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.CustomerName : null))
                 .ForMember(dest => dest.TicketCategory, opt => opt.MapFrom(src => src.TicketCategory != null ? src.TicketCategory.Description : null))
                 .ForMember(dest => dest.EventId, opt => opt.MapFrom(src=> src.TicketCategory!=null ? src.TicketCategory.EventId:0));
            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.TicketCategory, opt => opt.Ignore());


            CreateMap<Order, OrderPatchDto>();
            CreateMap<OrderPatchDto, Order>().ForMember(dest => dest.TicketCategory, opt => opt.Ignore())
                .ForMember(dest => dest.OrderId, opt => opt.Ignore());
        }
    }
}