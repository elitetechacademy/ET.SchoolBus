using System;

namespace ET.SchoolBus.Domain.Common;

public abstract class BaseEntity
{
    public string CreatedUser { get; set; }
    public DateTime CreatedTime { get; set; }
    public string UpdatedUser { get; set; }
    public DateTime UpdatedTime { get; set; }
    public bool Status { get; set; } = true;
}
