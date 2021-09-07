using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookStore.Domain;
using System.Collections.Generic;

namespace OnlineBookStore.Infrastructure.EntityConfigurations
{
	public class AuthorConfiguration : IEntityTypeConfiguration<Author>
	{
		public void Configure(EntityTypeBuilder<Author> builder)
        {
			builder.HasMany(a => a.Books)
				   .WithMany(p => p.Authors)
				   .UsingEntity<Dictionary<string, object>>(
					  "AuthorBook",
					  j => j
						.HasOne<Book>()
						.WithMany()
						.HasForeignKey("BookId")
						.OnDelete(DeleteBehavior.Cascade),
					  j => j
						.HasOne<Author>()
						.WithMany()
						.HasForeignKey("AuthorId")
						.OnDelete(DeleteBehavior.Restrict));			

		}
	}
}
