using System;
using ET.SchoolBus.Data.Mappings.Common;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.SchoolBus.Data.Mappings;

public class ApplicationUserMapping : BaseMapping<ApplicationUser>
{
    public override void ConfiguraDerivedEntity(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(x => x.UserId);
        builder.Property(x => x.UserId)
            .HasColumnOrder(1);

        builder.Property(x => x.RoleId)
            .HasColumnOrder(2);

        builder.Property(x => x.UserName)
            .HasColumnType("nvarchar(10)")
            .IsRequired()
            .HasColumnOrder(3);

        builder.Property(x => x.Password)
            .HasColumnType("nvarchar(150)")
            .IsRequired()
            .HasColumnOrder(4);

        builder.Property(x => x.Email)
            .HasColumnType("nvarchar(100)")
            .IsRequired()
            .HasColumnOrder(5);

        builder.Property(x => x.LastLoginDate)
            .HasColumnOrder(6);

        builder.Property(x => x.IsLocked)
            .IsRequired()
            .HasColumnOrder(7);

        builder.HasOne(x => x.Role)
            .WithMany(x => x.ApplicationUsers)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("ApplicationUsers");
    }
}
