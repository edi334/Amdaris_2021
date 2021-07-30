using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes
{
    class Robot
    {
        public Robot()
        {
            CreationDate = DateTime.Now;
        }
        public Robot(DateTime creationDate)
        {
            CreationDate = creationDate;
        }
        public string Name { get; set; }
        public string Material { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual string Sing()
        {
            return "I am a normal robot I don't know how to sing!";
        }
        public override string ToString()
        {
            return $"My name is {Name} and I am made out of {Material}!";
        }
    }
}
