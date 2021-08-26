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
    public class RaceConfig : IEntityTypeConfiguration<Race>
    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {
            builder.HasMany(x => x.Sessions)
                .WithOne(x => x.Race)
                .HasForeignKey(x => x.RaceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
