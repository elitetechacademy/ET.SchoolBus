using System;
using ET.SchoolBus.Data.Mappings.Common;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.SchoolBus.Data.Mappings;

public class BrandMapping : BaseMapping<Brand>
{
    public override void ConfiguraDerivedEntity(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(x => x.BrandId);
        builder.Property(x => x.BrandId).HasColumnName("BrandId")
            .HasColumnOrder(1);

        builder.Property(x => x.BrandName).HasColumnType("nvarchar(30)")
            .HasColumnName("BrandName")
            .HasColumnOrder(2);

        // builder.HasMany(x => x.Models)
        //     .WithOne(x => x.Brand)
        //     .HasForeignKey(x => x.BrandId)
        //     .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Brands");
    }
}
