using F1Management.Core.Models;
using F1Management.Core.Models.TeamMembers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public int Points { get; set; }
        [MaxLength(3)]
        public ICollection<Driver> Drivers { get; set; }
        [MaxLength(6)]
        public ICollection<CarMechanic> CarMechanics { get; set; }
        public PitStopCrew PitStopCrew { get; set; }
        [MaxLength(2)]
        public ICollection<RaceEngineer> RaceEngineers { get; set; }
    }
}
