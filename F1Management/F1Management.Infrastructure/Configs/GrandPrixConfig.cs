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
    public class GrandPrixConfig : IEntityTypeConfiguration<GrandPrix>
    {
        public void Configure(EntityTypeBuilder<GrandPrix> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasMany(x => x.CarSessions)
                .WithOne(x => x.GrandPrix)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
