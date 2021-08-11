﻿using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Roles.Mechanics
{
    public abstract class Mechanic : Role
    {
        public abstract void FixCar(RaceCar Car);
    }
}
