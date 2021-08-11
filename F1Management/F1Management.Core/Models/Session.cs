using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models
{
    public class Session
    {
        public Session(string teamId)
        {
            TeamId = teamId;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string TeamId { get; }
        public int Position { get; set; }
    }
}
