using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserModule.Core.Commands.Users.Register;
using UserModule.Core.Services;
using UserModule.Data;

namespace UserModule.Core
{
    public static class UserModuleBootstrapper
    {
        public static IServiceCollection InitUserModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<UserContext>(option =>
            {
                option.UseSqlServer(config.GetConnectionString("User_Context"));
            });

            services.AddMediatR(typeof(UserModuleBootstrapper).Assembly);

            services.AddScoped<IUserFacade, UserFacade>();


            services.AddValidatorsFromAssembly(typeof(UserModuleBootstrapper).Assembly);

            return services;
        }
    }

}
