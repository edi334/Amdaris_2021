﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Roles.Mechanics
{
    abstract class Mechanic : Role
    {
        public abstract void FixCar(string CarId);
    }
}
