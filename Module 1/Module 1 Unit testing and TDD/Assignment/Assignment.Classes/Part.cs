using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes
{
    public class Part
    {
        public int Wear { get; set; }
        public override string ToString()
        {
            return $"{Wear}";
        }
    }
}
