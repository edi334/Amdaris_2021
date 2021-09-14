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
    public class ChassisConfig : IEntityTypeConfiguration<Chassis>
    {
        public void Configure(EntityTypeBuilder<Chassis> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.RaceCar)
                .WithOne(x => x.Chassis)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
