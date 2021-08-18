using F1Management.Core.Models.Abstractions;
using F1Management.Core.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure
{
    public class InMemoryRoleRepository : IRoleRepository
    {
        private List<Role> _roles;
        public InMemoryRoleRepository(List<Role> roles)
        {
            _roles = roles;
        }

        public Role GetByName(string name)
        {
            return _roles.Find(r => r.RoleName == name);
        }
    }
}
