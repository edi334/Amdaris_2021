using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class WorkshopParticipant
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
        public int WorkshopId { get; set; }
        public Workshop Workshop { get; set; }
    }
}
