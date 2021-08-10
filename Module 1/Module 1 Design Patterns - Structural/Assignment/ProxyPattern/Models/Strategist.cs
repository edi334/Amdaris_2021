using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Models
{
    class Strategist : ICommunicator
    {
        public Strategist(Driver driver)
        {
            Driver = driver;

        }
        public Strategist(Driver driver, string engineerName) : this(driver)
        {
            _engineerName = engineerName;
        }
        public string Name { get; set; }
        public Driver Driver { get; set; }
        public RaceEngineer Engineer { get; set; }
        private string _engineerName { get; set; }
        public string PreferedStrategy { get; set; }

        public void Talk()
        {
            if (Engineer == null)
            {
                Engineer = new RaceEngineer(Driver, _engineerName);
            }
            Console.Write($"{Engineer.Name} says: ");
            Engineer.Talk();
            Console.WriteLine($"Setting strategy to: {PreferedStrategy}!");
            Driver.Strategy = PreferedStrategy;
        }
    }
}
