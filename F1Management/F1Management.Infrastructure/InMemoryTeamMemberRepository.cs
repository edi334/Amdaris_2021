using F1Management.Core;
using F1Management.Core.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure
{
    public class InMemoryTeamMemberRepository : ITeamMemberRepository
    {
        private List<TeamMember> _teamMembers;
        private InMemoryRoleRepository _roleRepository;
        public InMemoryTeamMemberRepository(List<TeamMember> teamMembers, InMemoryRoleRepository roleRepository)
        {
            _teamMembers = teamMembers;
            _roleRepository = roleRepository;
        }
        public List<TeamMember> GetAll()
        {
            return _teamMembers;
        }

        public TeamMember GetById(string id)
        {
            return _teamMembers.Find(m => m.Id == id);
        }

        public List<TeamMember> GetByRole(string roleName)
        {
            return _teamMembers
                .Where(m => m.RoleId == _roleRepository.GetByName(roleName).Id)
                .ToList();
        }

        public TeamMember GetFirstByRole(string roleName)
        {
            return _teamMembers.First(m => m.RoleId == _roleRepository.GetByName(roleName).Id);
        }
    }
}
