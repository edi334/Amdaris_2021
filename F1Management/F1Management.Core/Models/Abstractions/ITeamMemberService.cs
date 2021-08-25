using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions
{
    public interface ITeamMemberService
    {
        public void JoinTeam(Team team);
        public void LeaveTeam(Team team);
    }
}
