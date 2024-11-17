using System;
using ET.SchoolBus.Data.Mappings.Common;
using ET.SchoolBus.Domain.Common;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.SchoolBus.Data.Mappings;

public class RoleMapping : BaseMapping<Role>
{
    public override void ConfiguraDerivedEntity(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.RoleId);
        builder.Property(x => x.RoleId)
            .HasColumnOrder(1);

        builder.Property(x => x.Name)
        .HasColumnType("nvarchar(15)")
        .HasColumnOrder(2);

        builder.Property(x => x.Detail)
        .HasColumnType("nvarchar(255)")
        .HasColumnOrder(3);

        builder.ToTable("Roles");
    }
}
