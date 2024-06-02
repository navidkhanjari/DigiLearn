using Common.Query;
using UserModule.Core.Queries._DTOs;

namespace UserModule.Core.Queries.GetUserById
{
    public class GetUserByIdQuery : IQuery<UserDto?>
    {
        public Guid Id { get; set; }
    }
}
