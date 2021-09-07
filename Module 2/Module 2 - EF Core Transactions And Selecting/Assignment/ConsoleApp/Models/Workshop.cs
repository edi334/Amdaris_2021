using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public string ShortDescription { get; set; }
        public ICollection<WorkshopParticipant> WorkshopParticipants { get; set; }
        public override string ToString()
        {
            return $"{Name}. The theme is {Theme}. {ShortDescription}\n";
        }
    }
}
