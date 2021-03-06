using F1Management.Core.Models.Abstractions.Repositories;
using F1Management.Core.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserAsync(User user)
        {
            if (user == null)
            {
                throw new Exception("User is null!");
            }

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddUserRoleAsync(UserRole userRole)
        {
            if (userRole == null)
            {
                throw new Exception("UserRole is null");
            }

            await _dbContext.UserRoles.AddAsync(userRole);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> FindUser(string email, string password)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            return await _dbContext.Roles
                .FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}
