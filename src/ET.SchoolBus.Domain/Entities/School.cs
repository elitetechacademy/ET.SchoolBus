using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.Entities;
 
public class School : BaseEntity, ITenantEntity
{
    public int SchoolId { get; set; } //Primary Key
    public int SeasonId { get; set; }    
    public string SchoolName { get; set; }
    public int StudentCount { get; set; }
    public int StartYear { get; set; }

    public ICollection<Driver> Drivers { get; set; }
    public ICollection<Student> Students { get; set; }
    public ICollection<Parent> Parents { get; set; }
    public ICollection<Hostes> Hosteses { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }
    public Season Season { get; set; }
}
