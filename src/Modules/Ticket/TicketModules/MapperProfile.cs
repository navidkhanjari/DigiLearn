using AutoMapper;
using TicketModules.Core.DTOs.Tickets;
using TicketModules.Data.Entities;

namespace TicketModules
{
   public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateTicketCommand, Ticket>().ReverseMap();
            CreateMap<TicketDto, Ticket>().ReverseMap();
            CreateMap<TicketMessageDto, TicketMessage>().ReverseMap();
        }
    }
}
