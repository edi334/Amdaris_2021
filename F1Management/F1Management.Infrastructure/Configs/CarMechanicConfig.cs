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
    class CarMechanicConfig : IEntityTypeConfiguration<CarMechanic>
    {
        public void Configure(EntityTypeBuilder<CarMechanic> builder)
        {
            builder.HasOne(x => x.Team)
                .WithMany(x => x.CarMechanics)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Member as CarMechanic)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
