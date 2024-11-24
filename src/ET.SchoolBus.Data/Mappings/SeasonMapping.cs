using System;
using ET.SchoolBus.Data.Mappings.Common;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.SchoolBus.Data.Mappings;

public class SeasonMapping : BaseMapping<Season>
{
    public override void ConfiguraDerivedEntity(EntityTypeBuilder<Season> builder)
    {
        builder.HasKey(x => x.SeasonId);
        builder.Property(x => x.SeasonId)
            .HasColumnOrder(1);

        builder.Property(x => x.Name)
            .HasColumnType("nvarchar(100)")
            .HasColumnOrder(2);

        builder.ToTable("Seasons");
    }
}
