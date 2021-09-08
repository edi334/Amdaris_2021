using F1Management.Core.Models.TeamMembers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Configs
{
    public class DriverConfig : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasOne(x => x.Team)
                .WithMany(x => x.Drivers)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Member as Driver)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.RaceCar)
                .WithOne(x => x.Driver)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.RaceEngineer)
                .WithOne(x => x.Driver)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
