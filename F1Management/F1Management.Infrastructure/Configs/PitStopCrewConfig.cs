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
    public class PitStopCrewConfig : IEntityTypeConfiguration<PitStopCrew>
    {
        public void Configure(EntityTypeBuilder<PitStopCrew> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasMany(x => x.PitStopMechanics)
                .WithOne(x => x.PitStopCrew)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Team)
                .WithOne(x => x.PitStopCrew)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
