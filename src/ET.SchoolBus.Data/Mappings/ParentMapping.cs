using System;
using ET.SchoolBus.Data.Mappings.Common;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.SchoolBus.Data.Mappings;

public class ParentMapping : BaseMapping<Parent>
{
    public override void ConfiguraDerivedEntity(EntityTypeBuilder<Parent> builder)
    {
        builder.HasKey(x => x.ParentId);
        builder.Property(x => x.ParentId)
        .HasColumnName("ParentId")
        .HasColumnOrder(1);

        builder.Property(x => x.SeasonId)
        .HasColumnOrder(2);

        builder.Property(x => x.ProfessionId)
        .HasColumnName("ProfessionId")
        .HasColumnOrder(3);

        builder.Property(x => x.SchoolId)
      .HasColumnName("SchoolId")
      .HasColumnOrder(4);

        builder.Property(x => x.Name)
        .HasColumnName("Name")
        .HasColumnType("nvarchar(30)")
        .HasColumnOrder(5);

        builder.Property(x => x.Surname)
        .HasColumnName("Surname")
        .HasColumnType("nvarchar(30)")
        .HasColumnOrder(6);

        builder.Property(x => x.PhoneNumber)
        .HasColumnName("PhoneNumber")
        .HasColumnType("nvarchar(13)")
        .HasColumnOrder(7);

        builder.Property(x => x.Email)
        .HasColumnName("Email")
        .HasColumnType("nvarchar(100)")
        .HasColumnOrder(8);

        builder.HasOne(x => x.Profession)
        .WithMany(x => x.Parents)
        .HasForeignKey(x => x.ParentId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.School)
        .WithMany(x => x.Parents)
        .HasForeignKey(x => x.SchoolId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Season)
        .WithMany(x => x.Parents)
        .HasForeignKey(x => x.SeasonId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Parents");
    }
}

//Ctrl+Shift+I Linux
//Shift+Alt+F Windows