using F1Management.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetByIdAsync(Guid id);
        public Task AddUserAsync(User user);
        public Task AddUserRoleAsync(UserRole userRole);
        public Task<Role> GetRoleByNameAsync(string name);
        public Task<User> FindUser(string email, string password);
    }
}
