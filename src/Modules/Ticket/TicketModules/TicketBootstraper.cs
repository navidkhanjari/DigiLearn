using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TicketModules.Data;

namespace TicketModules
{
    public static class TicketBootstraper
    {
        public static IServiceCollection InitTicketModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TicketContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("Ticket_Context"));
            });
            services.AddAutoMapper(typeof(MapperProfile).Assembly);

            return services;
        }
    }
}
