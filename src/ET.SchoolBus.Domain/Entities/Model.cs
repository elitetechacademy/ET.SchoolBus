using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.Entities;

public class Model : BaseEntity
{
    public int ModelId { get; set; } //Primary Key
    public int BrandId { get; set; } //Foreign Key
    public string ModelName { get; set; }

    public Brand Brand { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }
}
