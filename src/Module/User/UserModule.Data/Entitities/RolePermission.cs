using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModule.Data.Entitities._Enums;

namespace UserModule.Data.Entitities
{
    public class RolePermission :BaseEntity
    {
        public Guid RoleId { get; set; }
        public Permissions Permissions { get; set; }

        public Role Role { get; set; }
    }
}
