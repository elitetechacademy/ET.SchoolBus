using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.Entities;

public class Brand : BaseEntity
{
    public int BrandId { get; set; } //Primary Key
    public string BrandName { get; set; }

    public ICollection<Vehicle> Vehicles { get; set; }

    public ICollection<Model> Models { get; set; }
}
