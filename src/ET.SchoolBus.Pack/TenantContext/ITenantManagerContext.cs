using System;

namespace ET.SchoolBus.Pack.TenantContext;

public interface ITenantManagerContext
{
    public int SeasonId { get;}
    void SetTenant(int seasonId);
}
