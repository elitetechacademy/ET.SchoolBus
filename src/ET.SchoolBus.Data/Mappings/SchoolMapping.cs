using System;
using ET.SchoolBus.Data.Mappings.Common;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.SchoolBus.Data.Mappings;

public class SchoolMapping : BaseMapping<School>
{
    public override void ConfiguraDerivedEntity(EntityTypeBuilder<School> builder)
    {
        builder.HasKey(x => x.SchoolId);
        builder.Property(x => x.SchoolId)
            .HasColumnName("SchoolId")
            .HasColumnOrder(1);

        builder.Property(x => x.SeasonId)
            .HasColumnOrder(2);

            builder.Property(x => x.SchoolName)
            .HasColumnName("SchoolName")
            .HasColumnType("nvarchar(100)")
            .HasColumnOrder(3);

            builder.Property(x => x.StudentCount)
            .HasColumnName("StudentCount")
            .HasColumnOrder(4);

            builder.Property(x => x.StartYear)
            .HasColumnName("StartYear")
            .HasColumnOrder(5);

            builder.ToTable("Schools");
    }
}
