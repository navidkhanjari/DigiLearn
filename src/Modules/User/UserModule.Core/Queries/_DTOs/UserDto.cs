using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserModule.Core.Queries._DTOs
{
   public class UserDto:BaseDto
    {
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
    }
}
