using F1Management.Core.Models.Car;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Configs
{
    public class TireSetConfig : IEntityTypeConfiguration<TireSet>
    {
        public void Configure(EntityTypeBuilder<TireSet> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FrontLeftWear)
                .HasDefaultValue(0);

            builder.Property(x => x.FrontRightWear)
                .HasDefaultValue(0);

            builder.Property(x => x.RearLeftWear)
                .HasDefaultValue(0);

            builder.Property(x => x.RearRightWear)
                .HasDefaultValue(0);

            builder.HasOne(x => x.RaceCar)
                .WithOne(x => x.TireSet)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
