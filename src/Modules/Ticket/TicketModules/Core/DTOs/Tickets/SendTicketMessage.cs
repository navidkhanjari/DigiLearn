using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketModules.Core.DTOs.Tickets
{
    public class SendTicketMessage
    {
        public Guid UserId { get; set; }
        public Guid TicketId { get; set; }
        public string OwnerFullName { get; set; }
        public string Text { get; set; }
    }
}
