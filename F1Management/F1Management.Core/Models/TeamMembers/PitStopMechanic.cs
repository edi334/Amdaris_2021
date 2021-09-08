﻿using F1Management.Core.Models.Car;
using F1Management.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.TeamMembers
{
    public class PitStopMechanic : Member
    {
        public Guid PitStopCrewId { get; set; }
        public PitStopCrew PitStopCrew { get; set; }
    }
}
