using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.Entities;

public class School : BaseEntity
{
    public int SchoolId { get; set; } //Primary Key
    public string SchoolName { get; set; }
    public int StudentCount { get; set; }
    public int StartYear { get; set; }

    public ICollection<Driver> Drivers { get; set; }
    public ICollection<Student> Students { get; set; }
    public ICollection<School> Schools { get; set; }
    public ICollection<Parent> Parents { get; set; }
    public ICollection<Hostes> Hosteses { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }
}
