using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int Ranking { get; set; }
        public List<TeamMember> TeamMembers { get; set; }
    }
}
