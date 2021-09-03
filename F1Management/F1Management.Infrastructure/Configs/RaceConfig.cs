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
    public class RaceConfig : IEntityTypeConfiguration<GrandPrix>
    {
        public void Configure(EntityTypeBuilder<GrandPrix> builder)
        {
            builder.HasMany(x => x.Sessions)
                .WithOne(x => x.Race)
                .HasForeignKey(x => x.RaceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
