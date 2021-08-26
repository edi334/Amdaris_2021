using F1Management.Core.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions
{
    public interface IRoleRepository
    {
        public List<Role> GetAll();
        public Role GetByName(string name);
        public Role GetById(Guid id);
        public void Add(Role role);
        public void Delete(Role role);
    }
}
