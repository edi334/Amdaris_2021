using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core
{
    public class Race
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CircuitName { get; set; }
    }
}
