using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes
{
    class Person
    {
        private string name;
        private string gender;
        public string Name { get { return name; } set { name = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public string AddresingFormula
        { 
            get
            {
                if (Gender == "Male")
                {
                    return $"Mr. {Name}";
                }
                else if (Gender == "Female")
                {
                    return $"Mrs. {Name}";
                }
                else
                {
                    return Name;
                }
            }
        }
        public virtual void Speak()
        {
            Console.WriteLine($"Hello, my Name is {Name}!");
        }
    }
}
