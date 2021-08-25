using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories
{
    public interface ITeamRepository
    {
        public List<Team> GetAll();
        public Team GetById(Guid id);
        public void Add(Team team);
        public void Delete(Team team);
    }
}
