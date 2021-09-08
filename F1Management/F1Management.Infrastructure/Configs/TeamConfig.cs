using F1Management.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Configs
{
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasMany(x => x.RaceEngineers)
                .WithOne(x => x.Team)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.CarMechanics)
                .WithOne(x => x.Team)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Drivers)
                .WithOne(x => x.Team)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.PitStopCrew)
                .WithOne(x => x.Team)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
