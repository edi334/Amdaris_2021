using F1Management.Core.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories
{
    public interface IDriverRepository
    {
        public List<Driver> GetAll();
        public Driver GetById(Guid id);
        public void Add(Driver driver);
        public void Delete(Driver driver);
    }
}
