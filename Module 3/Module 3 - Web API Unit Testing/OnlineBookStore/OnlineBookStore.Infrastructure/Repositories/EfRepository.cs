using Microsoft.EntityFrameworkCore;
using OnlineBookingStore.Application.Interfaces;
using OnlineBookStore.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookStore.Infrastructure.Repositories
{
	public class EfRepository<T> : IRepository<T> where T : Entity<int>
	{
        protected readonly BookingStoreDbContext _dbContext;

		public IUnitOfWork UnitOfWork => _dbContext;

		public EfRepository(BookingStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Read() => _dbContext.Set<T>();

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            return await _dbContext.Set<T>().FindAsync(keyValues, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            var entry = await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
            return entry.Entity;            
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;            
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);            
        }
    }
}
