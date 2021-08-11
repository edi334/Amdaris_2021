﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Roles
{
    public class RaceEngineer : Admin
    {
        public RaceEngineer(string driverId)
        {
            DriverId = driverId;
        }
        public string DriverId { get; set; }
    }
}