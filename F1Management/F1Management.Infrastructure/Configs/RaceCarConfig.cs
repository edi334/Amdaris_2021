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
    public class RaceCarConfig : IEntityTypeConfiguration<RaceCar>
    {
        public void Configure(EntityTypeBuilder<RaceCar> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Chassis)
                .WithOne(x => x.RaceCar)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Engine)
                .WithOne(x => x.RaceCar)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Gearbox)
                .WithOne(x => x.RaceCar)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.TireSet)
                .WithOne(x => x.RaceCar)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Driver)
                .WithOne(x => x.RaceCar)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.CarSessions)
                .WithOne(x => x.RaceCar)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
