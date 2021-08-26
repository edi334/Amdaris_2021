﻿using F1Management.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core
{
    public class Race : BaseEntity
    {
        public string Name { get; set; }
        public string CircuitName { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
