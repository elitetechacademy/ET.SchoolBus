using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.Entities;

public class Student : BaseEntity, ITenantEntity
{
    public int StudentId { get; set; } //Primary Key
    public int VehicleId { get; set; } //Foreign Key
    public int SchoolId{get; set;} //Foreign Key
    public string IdentityNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public double TotalPrice { get; set; }

    public Vehicle Vehicle { get; set; }
    public School School { get; set; }
    public ICollection<StudentParent> StudentParents { get; set; }
    
}
