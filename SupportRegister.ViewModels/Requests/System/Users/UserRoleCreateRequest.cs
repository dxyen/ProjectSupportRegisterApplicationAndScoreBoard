using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.Requests.System.Users
{
    public class UserRoleCreateRequest
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
