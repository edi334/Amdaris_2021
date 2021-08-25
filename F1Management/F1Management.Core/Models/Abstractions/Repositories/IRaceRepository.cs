using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories
{
    public interface IRaceRepository
    {
        public List<Race> GetAll();
        public Race GetById(Guid id);
        public void Add(Race race);
        public void Delete(Race race);
    }
}
