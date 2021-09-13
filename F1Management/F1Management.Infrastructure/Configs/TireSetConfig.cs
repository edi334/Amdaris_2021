﻿using F1Management.Core.Models.Car;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Configs
{
    public class TireSetConfig : IEntityTypeConfiguration<TireSet>
    {
        public void Configure(EntityTypeBuilder<TireSet> builder)
        {
            builder.HasOne(x => x.RaceCar)
                .WithOne(x => x.TireSet)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}