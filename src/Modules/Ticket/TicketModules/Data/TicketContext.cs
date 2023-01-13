using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketModules.Data.Entities;

namespace TicketModules.Data
{
    class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> option) : base(option)
        {

        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }
    }
}
