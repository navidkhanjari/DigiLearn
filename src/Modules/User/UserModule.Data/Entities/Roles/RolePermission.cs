using Common.Domain;

namespace UserModule.Data.Entities.Roles
{
    public class RolePermission : BaseEntity
    {
        public Guid RoleId { get; set; }
        public Permissions Permissions { get; set; }
    }
}
