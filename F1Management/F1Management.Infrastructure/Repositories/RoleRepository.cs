using F1Management.Core.Models.Abstractions;
using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Repositories
{
    public class RoleRepository : IGenericRepository<Role>, IRoleRepository
    {
        private readonly AppDbContext _dbContext;

        public RoleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Role role)
        {
            _dbContext.Roles.Add(role);
            _dbContext.SaveChanges();
        }

        public void Delete(Role role)
        {
            _dbContext.Roles.Remove(role);
            _dbContext.SaveChanges();
        }

        public List<Role> GetAll()
        {
            return _dbContext.Roles.ToList();
        }

        public Role GetById(Guid id)
        {
            return _dbContext.Roles.FirstOrDefault(r => r.Id == id);
        }

        public Role GetByName(string name)
        {
            return _dbContext.Roles.FirstOrDefault(r => r.Name == name);
        }

        public void Update(Role role)
        {
            _dbContext.Roles.Update(role);
            _dbContext.SaveChanges();
        }
    }
}
