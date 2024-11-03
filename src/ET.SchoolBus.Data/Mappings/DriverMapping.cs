using System;
using ET.SchoolBus.Data.Mappings.Common;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.SchoolBus.Data.Mappings;

public class DriverMapping : BaseMapping<Driver>
{

    public override void ConfiguraDerivedEntity(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(x => x.DriverId);
        builder.Property(x => x.DriverId)
        .HasColumnName("DriverId")
        .HasColumnOrder(1);

        builder.Property(x => x.SchoolId)
        .HasColumnName("SchoolId")
        .HasColumnOrder(2);

        builder.Property(x => x.Name)
        .HasColumnName("Name")
        .HasColumnType("nvarchar(30)")
        .HasColumnOrder(3);

        builder.Property(x => x.Surname)
        .HasColumnName("Surname")
        .HasColumnType("nvarchar(30)")
        .HasColumnOrder(4);

        builder.Property(x => x.PhoneNumber)
        .HasColumnName("PhoneNumber")
        .HasColumnType("nvarchar(13)")
        .HasColumnOrder(5);

        builder.Property(x => x.Address)
        .HasColumnName("Address")
        .HasColumnType("nvarchar(255)")
        .HasColumnOrder(6);

        builder.Property(x => x.Email)
        .HasColumnName("Email")
        .HasColumnType("nvarchar(100)")
        .HasColumnOrder(7);

        builder.HasOne(x => x.School)
        .WithMany(x => x.Drivers)
        .HasForeignKey(x => x.SchoolId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Vehicle)
        .WithOne(x => x.Driver)
        .HasForeignKey<Driver>(x => x.DriverId)
        .OnDelete(DeleteBehavior.NoAction)
        .IsRequired();

        builder.ToTable("Drives");
    }
}
