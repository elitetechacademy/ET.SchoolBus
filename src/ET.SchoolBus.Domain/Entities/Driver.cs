using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.Entities;

//Child
public class Driver : BaseEntity, ITenantEntity
{
    public int DriverId { get; set; } //Primary Key
    public int VehicleId { get; set; } //Foreign Key
    public int SchoolId { get;set; } //Foreign Key
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }

    public Vehicle Vehicle { get; set; } //one to one
    public School School { get; set; } //one to many
}
