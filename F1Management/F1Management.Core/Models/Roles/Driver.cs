using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Roles
{
    class Driver : Role
    {
        public int Number { get; set; }
        public int Points { get; set; }
        public string CarId { get; set; }
    }
}
