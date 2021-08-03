using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ArcticHare : Hare
    {
        public ArcticHare()
        {
            FurColor = "white";
        }
        public override void Action()
        {
            Console.WriteLine($"{Name} jumps in the snow.");
        }
        public override string ToString()
        {
            return IsSleeping ? $"{Name} is a sleeping Arctic Hare." : $"{Name} is an Arctic Hare that is currently not sleeping.";
        }
    }
}
