using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Models
{
    class F1Driver : Driver
    {
        public string Name { get; set; }
        public string Team { get; set; }
        public override void GetDescription()
        {
            Console.WriteLine($"I am {Name} and I drive for {Team}!");
        }
    }
}
