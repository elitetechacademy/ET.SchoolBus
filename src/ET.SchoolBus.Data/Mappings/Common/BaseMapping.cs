using System;
using ET.SchoolBus.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.SchoolBus.Data.Mappings.Common;

public abstract class BaseMapping<T> : IEntityTypeConfiguration<T>
    where T : BaseEntity, new()
{
    public abstract void ConfiguraDerivedEntity(EntityTypeBuilder<T> builder);

    public void Configure(EntityTypeBuilder<T> builder)
    {
        ConfiguraDerivedEntity(builder);

        builder.Property(x => x.CreatedUser).HasColumnType("nvarchar(50)")
            .HasColumnName("CreatedUser")
            .HasColumnOrder(11);

        builder.Property(x => x.CreatedTime)
            .HasColumnName("CreatedTime")
            .HasColumnOrder(12);

        builder.Property(x => x.UpdatedUser)
            .HasColumnName("UpdatedUser")
            .HasColumnOrder(13);

        builder.Property(x => x.UpdatedTime)
            .HasColumnName("UpdatedTime")
            .IsRequired(false)
            .HasColumnOrder(14);

        builder.Property(x => x.Status)
            .HasColumnName("IsActive")
            .HasDefaultValueSql("1")
            .HasColumnOrder(15);
    }
}
