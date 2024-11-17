using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.Entities;

public class Role : BaseEntity
{
    public int RoleId { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public ICollection<ApplicationUser> ApplicationUsers { get; set; }
}
