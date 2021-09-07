using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookStore.Domain;


namespace OnlineBookStore.Infrastructure.EntityConfigurations
{
	public class PriceOfferConfiguration : IEntityTypeConfiguration<PriceOffer>
	{
		public void Configure(EntityTypeBuilder<PriceOffer> builder)
		{
			builder.HasOne(x => x.Book)
				   .WithOne(x => x.PriceOffer)
				   .HasForeignKey<PriceOffer>(po => po.Id);			
		}
	}
}
