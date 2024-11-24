using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.Entities;

public class Season : BaseEntity
{
    public int SeasonId { get; set; }
    public string Name { get; set; }

    public ICollection<Driver> Drivers { get; set; }
    public ICollection<Hostes> Hosteses { get; set; }
    public ICollection<Parent> Parents { get; set; }
    public ICollection<Student> Students { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }
    public ICollection<School> Schools { get; set; }
}
