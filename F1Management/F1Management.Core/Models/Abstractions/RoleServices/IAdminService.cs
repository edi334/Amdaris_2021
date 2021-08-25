using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions
{
    public interface IAdminService
    {
        public void SendInvitationLink();
        public void EditTeamMemberRole();
    }
}
