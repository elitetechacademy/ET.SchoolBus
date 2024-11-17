using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.Entities;

public class ApplicationUser : BaseEntity
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public bool IsLocked { get; set; }=false;

    public Role Role { get; set; }
}
