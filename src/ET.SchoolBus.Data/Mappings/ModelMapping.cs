using System;
using ET.SchoolBus.Data.Mappings.Common;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.SchoolBus.Data.Mappings;

public class ModelMapping : BaseMapping<Model>
{
    public override void ConfiguraDerivedEntity(EntityTypeBuilder<Model> builder)
    {
        builder.HasKey(x => x.ModelId);
        builder.Property(x => x.ModelId).HasColumnName("ModelId")
            .HasColumnOrder(1);

            builder.Property(x => x.BrandId)
            .HasColumnName("BrandId")
            .HasColumnOrder(2);

        builder.Property(x => x.ModelName).HasColumnType("nvarchar(30)")
            .HasColumnName("ModelName")
            .HasColumnOrder(3);

        //Navigation Properties
        builder.HasOne(x => x.Brand)
            .WithMany(x => x.Models)
            .HasForeignKey(x => x.BrandId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Models");
    }
}
