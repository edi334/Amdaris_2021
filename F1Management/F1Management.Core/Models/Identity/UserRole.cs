using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Identity
{
    public class UserRole : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
