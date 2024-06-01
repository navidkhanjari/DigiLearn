using Common.Application;

namespace UserModule.Core.Commands.Register
{
    public class RegisterUserCommand : IBaseCommand<Guid>
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
