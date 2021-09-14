using F1Management.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Configs
{
    public class CarSessionConfig : IEntityTypeConfiguration<CarSession>
    {
        public void Configure(EntityTypeBuilder<CarSession> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.GrandPrix)
                .WithMany(x => x.CarSessions)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.RaceCar)
                .WithMany(x => x.CarSessions)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.PitStops)
                .WithOne(x => x.Session)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
