using F1Management.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public List<TeamMember> TeamMembers { get; set; }
    }
}
