using F1Management.Core.Models;
using F1Management.Core.Models.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core
{
    public class TeamMember : BaseEntity
    {
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
        //public Guid RoleId { get; set; }
        //public Role Role { get; set; }
        public string Name { get; set; }
    }
}
