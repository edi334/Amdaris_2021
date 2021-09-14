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
    public class PitStopConfig : IEntityTypeConfiguration<PitStop>
    {
        public void Configure(EntityTypeBuilder<PitStop> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Session)
                .WithMany(x => x.PitStops)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.OldTires)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.NewTires)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
