using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.Entities;

public class Hostes : BaseEntity, ITenantEntity
{
    public int SeasonId { get; set; }
    public int HostesId { get; set; } //Primary Key
    public int SchoolId { get; set; } //Foreign Key
    public int VehicleId { get; set; } //Foreign Key
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }

    public Vehicle Vehicle { get; set; }
    public School School { get; set; }
    public Season Season { get; set; }
}
