using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Models
{
    class Driver
    {
        public Driver()
        {
            Strategy = "Waiting for strategy...";
        }
        public string Name { get; set; }
        public int Points { get; set; }
        public string Strategy { get; set; }
        public string Position { get; set; }
    }
}
