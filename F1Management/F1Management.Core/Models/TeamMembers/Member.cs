using F1Management.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.TeamMembers
{
    public class Member : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
