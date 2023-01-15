using AutoMapper;
using Common.Application;
using Common.Application.SecurityUtil;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketModules.Core.DTOs.Tickets;
using TicketModules.Data;
using TicketModules.Data.Entities;

namespace TicketModules.Core.Services
{
    class TicketService : ITicketService
    {
        #region DI
        private readonly TicketContext _context;
        private readonly IMapper _mapper;
        public TicketService(TicketContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        #endregion
        public async Task<OperationResult> CloseTicket(Guid ticketId)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId);
            if (ticket == null)
                return OperationResult.NotFound();
            ticket.TicketStatus = TicketStatus.Closed;
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
            return OperationResult.Success();
        }

        public async Task<OperationResult<Guid>> CreateTicket(CreateTicketCommand command)
        {
            var ticket = _mapper.Map<Ticket>(command);

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return OperationResult<Guid>.Success(ticket.Id);
        }

        public async Task<TicketDto> GetTicket(Guid ticketId)
        {
            var ticket = await _context.Tickets
                .Include(c=> c.Messages)
                .FirstOrDefaultAsync(t => t.Id == ticketId);

            return _mapper.Map<TicketDto>(ticket);
        }

        public async Task<OperationResult> SendMessageInTicket(SendTicketMessageCommand command)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == command.TicketId);
            if (ticket == null)
                return OperationResult.NotFound();

            var message = new TicketMessage() {

                Text = command.Text.SanitizeText(),
                TicketId = command.TicketId,
                UserId = command.UserId,
                UserFullName = command.OwnerFullName
            };

            if (ticket.UserId == command.UserId)
            {
                ticket.TicketStatus = TicketStatus.Pending;
            }
            else
            {
                ticket.TicketStatus = TicketStatus.Answered;
            }
            _context.TicketMessages.Add(message);
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
            return OperationResult.Success();
        }
    }
}
