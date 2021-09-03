using F1Management.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.TeamMembers
{
    public class RaceEngineer : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid DriverId { get; set; }
        public Driver Driver { get; set; }
        public void SetStrategy(string strategy) { }
        public void TalkToDriver() { }
    }
}
