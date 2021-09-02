using F1Management.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Identity
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
