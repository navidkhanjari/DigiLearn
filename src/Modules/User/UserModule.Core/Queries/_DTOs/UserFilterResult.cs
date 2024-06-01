using Common.Query.Filter;

namespace UserModule.Core.Queries._DTOs
{
    public class UserFilterResult : BaseFilter<UserDto>
    {

    }
    public class UserFilterParams : BaseFilterParam
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
