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
    public class PitStopMechanicConfig : IEntityTypeConfiguration<PitStopMechanic>
    {
        public void Configure(EntityTypeBuilder<PitStopMechanic> builder)
        {
            builder.HasOne(x => x.User)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.PitStopCrew)
                .WithMany(x => x.PitStopMechanics)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
