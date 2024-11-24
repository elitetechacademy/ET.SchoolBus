using System;
using ET.SchoolBus.Data.Mappings.Common;
using ET.SchoolBus.Domain.Common;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace ET.SchoolBus.Data.Mappings;

public class VehicleMapping : BaseMapping<Vehicle>
{
    public override void ConfiguraDerivedEntity(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(x => x.VehicleId);
        builder.Property(x => x.VehicleId)
            .HasColumnName("VehicleId")
            .HasColumnOrder(1);

        builder.Property(x => x.SeasonId)
        .HasColumnOrder(2);

        builder.Property(x => x.SchoolId)
        .HasColumnName("SchoolId")
        .HasColumnOrder(3);

        builder.Property(x => x.BrandId)
        .HasColumnName("BrandId")
        .HasColumnOrder(4);

        builder.Property(x => x.ModelId)
        .HasColumnName("ModelId")
        .HasColumnOrder(5);

        builder.Property(x => x.Capacity)
        .HasColumnName("Capacity")
        .HasColumnOrder(6);

        builder.Property(x => x.ModelYear)
        .HasColumnName("ModelYear")
        .HasColumnOrder(7);

        builder.HasOne(x => x.Brand)
        .WithMany(x => x.Vehicles)
        .HasForeignKey(x => x.BrandId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Model)
       .WithMany(x => x.Vehicles)
       .HasForeignKey(x => x.ModelId)
       .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.School)
       .WithMany(x => x.Vehicles)
       .HasForeignKey(x => x.SchoolId)
       .OnDelete(DeleteBehavior.NoAction);

         builder.HasOne(x => x.Season)
       .WithMany(x => x.Vehicles)
       .HasForeignKey(x => x.SeasonId)
       .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Vehicles");
    }
}
