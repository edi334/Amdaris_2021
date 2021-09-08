using F1Management.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.TeamMembers
{
    public class RaceEngineer : Member
    {
        public Guid DriverId { get; set; }
        public Driver Driver { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
