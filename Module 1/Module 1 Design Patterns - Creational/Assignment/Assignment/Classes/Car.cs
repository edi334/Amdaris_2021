using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes
{
    public class Car
    {
        public string Name { get; set; }
        public string Team { get; set; }
        public int HorsePower { get; set; }
        public string Chassis { get; set; }
        public Driver Driver { get; set; }
        public override string ToString()
        {
            return $"{Name} {Team} {HorsePower} {Chassis} {Driver.Name}";
        }
    }
}
