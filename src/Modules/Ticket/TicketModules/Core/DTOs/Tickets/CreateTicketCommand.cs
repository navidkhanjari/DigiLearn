using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketModules.Core.DTOs.Tickets
{
    public class CreateTicketCommand
    {
        public Guid UserId { get; set; }
        public string OwnerFullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
