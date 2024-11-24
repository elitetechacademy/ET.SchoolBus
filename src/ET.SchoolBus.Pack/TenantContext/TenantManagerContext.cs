using System;

namespace ET.SchoolBus.Pack.TenantContext;

public class TenantManagerContext : ITenantManagerContext
{
    public int SeasonId { get; private set; } = 1;

    public void SetTenant(int seasonId)
    {
        SeasonId = seasonId;
    }
}
