using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core
{
    public class TeamMember
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string RoleId { get; set; }
        public string Name { get; set; }
        public void JoinTeam() { }
        public void LeaveTeam() { }
    }
}
