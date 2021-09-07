using Microsoft.EntityFrameworkCore;
using OnlineBookingStore.Application.Interfaces;
using OnlineBookStore.Domain;
using OnlineBookStore.Infrastructure.EntityConfigurations;

namespace OnlineBookStore.Infrastructure
{
	public class BookingStoreDbContext : DbContext, IUnitOfWork
	{
        public BookingStoreDbContext()
        {
        }

        public BookingStoreDbContext(DbContextOptions<BookingStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Review> Reviews { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfiguration).Assembly);
        }       
	}
}
