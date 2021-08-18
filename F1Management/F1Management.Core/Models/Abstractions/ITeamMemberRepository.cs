using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions
{
    public interface ITeamMemberRepository
    {
        public List<TeamMember> GetAll();
        public List<TeamMember> GetByRole(string roleName);
        public TeamMember GetById(string id);
        public TeamMember GetFirstByRole(string roleName);
    }
}
