using System;
using ET.SchoolBus.Data.Mappings.Common;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.SchoolBus.Data.Mappings;

public class HostesMapping : BaseMapping<Hostes>
{

    public override void ConfiguraDerivedEntity(EntityTypeBuilder<Hostes> builder)
    {
        builder.HasKey(x => x.HostesId);
        builder.Property(x => x.HostesId)
        .HasColumnName("HostesId")
        .HasColumnOrder(1);

        builder.Property(x => x.SchoolId)
        .HasColumnName("SchoolId")
        .HasColumnOrder(2);

        builder.Property(x => x.VehicleId)
        .HasColumnName("VehicleId")
        .HasColumnOrder(3);

        builder.Property(x => x.Name)
        .HasColumnName("Name")
        .HasColumnType("nvarchar(30)")
        .HasColumnOrder(4);

        builder.Property(x => x.Surname)
        .HasColumnName("Surname")
        .HasColumnType("nvarchar(30)")
        .HasColumnOrder(5);

        builder.Property(x => x.PhoneNumber)
        .HasColumnName("PhoneNumber")
        .HasColumnType("nvarchar(13)")
        .HasColumnOrder(6);

        builder.Property(x => x.Address)
        .HasColumnName("Address")
        .HasColumnType("nvarchar(255)")
        .HasColumnOrder(7);

        builder.Property(x => x.Email)
        .HasColumnName("Email")
        .HasColumnType("nvarchar(100)")
        .HasColumnOrder(8);

        builder.HasOne(x => x.Vehicle)
        .WithOne(x => x.Hostes)
        .HasForeignKey<Vehicle>(x => x.VehicleId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.School)
        .WithMany(x => x.Hosteses)
        .HasForeignKey(x => x.SchoolId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Hostesses");
    }
}
