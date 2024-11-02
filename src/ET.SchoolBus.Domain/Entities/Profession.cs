using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.Entities;

public class Profession : BaseEntity
{
    public int ProfessionId { get; set; } //Primary Key
    public string Name { get; set; }

    public ICollection<Parent> Parents { get; set; }
}
