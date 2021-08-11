using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions
{
    public interface IMemberService
    {
        public void AssignRoleToMember(string roleId);
        public List<TeamMember> GetAllDrivers();
        public List<TeamMember> GettAllMechanics();
        public List<TeamMember> GetAllAdmins();
    }
}
