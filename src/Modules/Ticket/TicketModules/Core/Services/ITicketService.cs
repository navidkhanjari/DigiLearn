using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketModules.Core.DTOs.Tickets;

namespace TicketModules.Core.Services
{
    public interface ITicketService
    {
        //command
        Task<OperationResult<Guid>> CreateTicket(CreateTicketCommand command);
        Task<OperationResult> SendMessageInTicket(SendTicketMessageCommand command);
        Task<OperationResult> CloseTicket(Guid ticketId);
        //query
        Task<TicketDto> GetTicket(Guid ticketId);
    }
}
