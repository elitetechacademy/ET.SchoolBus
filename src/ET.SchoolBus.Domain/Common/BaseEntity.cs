using System;

namespace ET.SchoolBus.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public string CreatedUser { get; set; }
    public DateTime CreatedTime { get; set; }
    public string UpdatedUser { get; set; }
    public DateTime UpdatedTime { get; set; }
}
