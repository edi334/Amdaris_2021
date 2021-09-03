﻿using F1Management.Core.Models.Car;
using F1Management.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.TeamMembers
{
    public class Driver : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int Number { get; set; }
        public int Points { get; set; }
        public string Strategy { get; set; }
        public RaceCar RaceCar { get; set; }
        public Guid RaceCarId { get; set; }
        public RaceEngineer RaceEngineer { get; set; }
    }
}
