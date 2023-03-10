using Common.Application;
using Common.Application.SecurityUtil;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserModule.Data;
using UserModule.Data.Entitities;

namespace UserModule.Core.Commands.Users.Register
{
    public class RegisterUserCommand:IBaseCommand<Guid>
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
    public class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand, Guid>
    {
        private readonly UserContext _context;

        public RegisterUserCommandHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<OperationResult<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (await _context.Users.AnyAsync(f => f.PhoneNumber == request.PhoneNumber))
            {
                return OperationResult<Guid>.Error("کاربر وارد شده  در سیستم موجود می باشد");
            }

            var user = new User()
            {
                PhoneNumber = request.PhoneNumber,
                Password = Sha256Hasher.Hash(request.Password),
                Avatar = "default.png",
                Id = Guid.NewGuid()
            };
            _context.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return OperationResult<Guid>.Success(user.Id);
        }
    }
    public class RegisterUserCommandValdator:AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValdator()
        {
            RuleFor(r => r.Password)
                .NotEmpty()
                .NotNull().MinimumLength(6);
        }
    }
}
