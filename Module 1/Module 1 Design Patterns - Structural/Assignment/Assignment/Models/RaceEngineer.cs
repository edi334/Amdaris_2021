using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Models
{
    class RaceEngineer : ICommunicator
    {
        public RaceEngineer(Driver driver, string engineerName)
        {
            Driver = driver;
            Name = engineerName;
        }
        public string Name { get; set; }
        public Driver Driver { get; set; }

        public void Talk()
        {
            Console.WriteLine($"You are currently in {Driver.Position}!");
        }
    }
}
