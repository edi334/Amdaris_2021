using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookStore.Domain;

namespace OnlineBookStore.Infrastructure.EntityConfigurations
{
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{            
            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.PublishedOn)
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(x => x.Publisher)
                   .IsRequired();                    

            builder.Property(x => x.RowVersion).IsRowVersion();
        }
	}
}
