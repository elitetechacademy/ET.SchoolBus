using System;
using System.Security.Cryptography.X509Certificates;
using ET.SchoolBus.Data.Mappings.Common;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.SchoolBus.Data.Mappings;

public class StudentParentMapping : BaseMapping<StudentParent>
{
    public override void ConfiguraDerivedEntity(EntityTypeBuilder<StudentParent> builder)
    {
        builder.HasKey(x => new { x.StudentId, x.ParentId });

        builder.Property(x => x.StudentId)
        .HasColumnName("StudentId")
        .HasColumnOrder(1);

        builder.Property(x => x.ParentId)
        .HasColumnName("ParentId")
        .HasColumnOrder(2);

        builder.HasOne(x => x.Parent)
        .WithMany(x => x.StudentParents)
        .HasForeignKey(x => x.ParentId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Student)
        .WithMany(x => x.StudentParents)
        .HasForeignKey(x => x.StudentId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("StudentParents");
    }
}
