﻿using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models
{
    public class Session : BaseEntity
    {
        public string Name { get; set; }
        public Guid GrandPrixId { get; set; }
        public GrandPrix GrandPrix { get; set; }
        public Guid RaceCarId { get; set; }
        public RaceCar RaceCar { get; set; }
        public int Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
