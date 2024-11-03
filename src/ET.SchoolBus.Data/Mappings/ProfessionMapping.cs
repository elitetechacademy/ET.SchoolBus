using System;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using ET.SchoolBus.Data.Mappings.Common;
using ET.SchoolBus.Domain.Common;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.SchoolBus.Data.Mappings;

public class ProfessionMapping : BaseMapping<Profession>
{
    public override void ConfiguraDerivedEntity(EntityTypeBuilder<Profession> builder)
    {
        builder.HasKey(x => x.ProfessionId);
        builder.Property(x => x.ProfessionId)
        .HasColumnName("ProfessionId")
        .HasColumnOrder(1);

        builder.Property(x => x.Name)
        .HasColumnName("Name")
        .HasColumnType("nvarchar(100)")
        .HasColumnOrder(2);

        builder.ToTable("Professions");
    }
}
