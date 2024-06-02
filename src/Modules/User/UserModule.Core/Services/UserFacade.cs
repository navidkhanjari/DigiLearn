using Common.Application;
using MediatR;
using UserModule.Core.Commands.Register;
using UserModule.Core.Queries._DTOs;
using UserModule.Core.Queries.GetByPhoneNumber;
using UserModule.Core.Queries.GetUserById;

namespace UserModule.Core.Services
{
    public class UserFacade : IUserFacade
    {
        private readonly IMediator _mediator;

        public UserFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        //commands
        public async Task<OperationResult<Guid>> RegisterUser(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }


        //queries
        public async Task<UserDto?> GetUserById(Guid id)
        {
            return await _mediator.Send(new GetUserByIdQuery());
        }

        public async Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _mediator.Send(new GetUserByPhoneNumberQuery());
        }
    }
}
