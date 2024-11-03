using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.Entities;

//Parent
public class Vehicle : BaseEntity, ITenantEntity
{
    public int VehicleId { get; set; } //Primary Key
    public int SchoolId { get; set; } // Foreign Key
    public string Plaque { get; set; }
    public int Capacity { get; set; }    
    public int BrandId { get; set; } //Foreign Key
    public int ModelId { get; set; } //Foreign Key
    public int ModelYear { get; set; }

    public Brand Brand { get; set; }
    public Model Model { get; set; }
    public Driver? Driver { get; set; }
    public Hostes? Hostes { get; set; }
    public School School { get; set; }

    public ICollection<Student> Students { get; set; }
}
