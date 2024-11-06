using System;
using ET.SchoolBus.Data.Mappings.Common;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.SchoolBus.Data.Mappings;

public class StudentMapping : BaseMapping<Student>
{
    //Ctrl+K+C  Comment
    //Ctrş+K+U  Uncomment



    public override void ConfiguraDerivedEntity(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.StudentId);
        builder.Property(x => x.StudentId)
        .HasColumnName("StudentId")
        .HasColumnOrder(1);

        builder.Property(x => x.VehicleId)
        .HasColumnName("VehicleId")
        .HasColumnOrder(2);

        builder.Property(x => x.SchoolId)
        .HasColumnName("SchoolId")
        .HasColumnOrder(3);

        builder.Property(x => x.IdentityNumber)
        .HasColumnName("IdentityNumber")
        .HasColumnType("nchar(11)")
        .HasColumnOrder(4);

        builder.Property(x => x.Name)
        .HasColumnName("Name")
        .HasColumnType("nvarchar(30)")
        .HasColumnOrder(5);

        builder.Property(x => x.Surname)
        .HasColumnName("Surname")
        .HasColumnType("nvarchar(30)")
        .HasColumnOrder(6);

        builder.Property(x => x.TotalPrice)
        .HasColumnName("TotalPrice")
        .HasColumnOrder(7);

        builder.HasOne(x => x.Vehicle)
        .WithMany(x => x.Students)
        .HasForeignKey(x => x.StudentId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.School)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.SchoolId)
                .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Students");
    }
}
