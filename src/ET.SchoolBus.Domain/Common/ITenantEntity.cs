using System;
using ET.SchoolBus.Domain.Entities;

namespace ET.SchoolBus.Domain.Common;

public interface ITenantEntity
{
    int SchoolId { get; set; }
    School School { get; set; }
}
