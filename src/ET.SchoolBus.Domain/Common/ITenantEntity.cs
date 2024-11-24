using System;
using ET.SchoolBus.Domain.Entities;

namespace ET.SchoolBus.Domain.Common;

public interface ITenantEntity
{
    int SeasonId { get; set; }
    Season Season { get; set; }
}
