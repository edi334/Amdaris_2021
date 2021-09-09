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
    public class RaceEngineerConfig : IEntityTypeConfiguration<RaceEngineer>
    {
        public void Configure(EntityTypeBuilder<RaceEngineer> builder)
        {
            builder.HasOne(x => x.User)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Team)
                .WithMany(x => x.RaceEngineers)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Driver)
                .WithOne(x => x.RaceEngineer)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
