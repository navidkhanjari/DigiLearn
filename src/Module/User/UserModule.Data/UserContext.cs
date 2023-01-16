using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModule.Data.Entitities;

namespace UserModule.Data
{
    public class UserContext:DbContext
    {
            public UserContext(DbContextOptions<UserContext> options) : base(options)
            {

            }

            public DbSet<User> Users { get; set; }
            public DbSet<Role> Roles { get; set; }
            public DbSet<UserRole> UserRoles { get; set; }
            public DbSet<RolePermission> RolePermissions { get; set; }     
    }
}
