using F1Management.Core.Models.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories
{
    public interface ITeamRepository
    {
        public void UpdateTeam(Team team);
        public void UpdateDriver(Driver driver);
    }
}
