using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<WorkshopParticipant> WorkshopParticipants { get; set; }
    }
}
