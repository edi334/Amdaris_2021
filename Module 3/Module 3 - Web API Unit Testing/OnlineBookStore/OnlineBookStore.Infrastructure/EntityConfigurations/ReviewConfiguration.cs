using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookStore.Domain;

namespace OnlineBookStore.Infrastructure.EntityConfigurations
{
	public class ReviewConfiguration : IEntityTypeConfiguration<Review>
	{
		public void Configure(EntityTypeBuilder<Review> builder)
		{
			builder.HasOne(x => x.Book)
				   .WithMany(x => x.Reviews)
				   .IsRequired()
				   .OnDelete(DeleteBehavior.Restrict);
		}
	}
}
