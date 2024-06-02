using Common.Application;
using UserModule.Core.Commands.Register;
using UserModule.Core.Queries._DTOs;

namespace UserModule.Core.Services
{
    public interface IUserFacade
    {
        Task<OperationResult<Guid>> RegisterUser(RegisterUserCommand command);

        Task<UserDto?> GetUserById(Guid id);
        Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
    }
}
