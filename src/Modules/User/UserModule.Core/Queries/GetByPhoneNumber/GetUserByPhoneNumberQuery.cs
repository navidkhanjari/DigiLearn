using Common.Query;
using UserModule.Core.Queries._DTOs;

namespace UserModule.Core.Queries.GetByPhoneNumber
{
    public class GetUserByPhoneNumberQuery : IQuery<UserDto?>
    {
        public string PhoneNumber { get; set; }
    }
}
