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
    public class GearboxConfig : IEntityTypeConfiguration<Gearbox>
    {
        public void Configure(EntityTypeBuilder<Gearbox> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Wear)
                .HasDefaultValue(0);

            builder.HasOne(x => x.RaceCar)
                .WithOne(x => x.Gearbox)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
