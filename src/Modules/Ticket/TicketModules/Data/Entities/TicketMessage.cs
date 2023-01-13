using Common.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace TicketModules.Data.Entities
{
    class TicketMessage : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid TicketId { get; set; }

        [MaxLength(100)]
        public string UserFullName { get; set; }
        public string Text { get; set; }


        public Ticket Ticket { get; set; }
    }
}
