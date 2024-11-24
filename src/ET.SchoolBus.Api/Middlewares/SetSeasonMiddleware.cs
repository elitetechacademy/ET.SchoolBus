using System;
using ET.SchoolBus.Pack.AppContext;
using ET.SchoolBus.Pack.TenantContext;
using Microsoft.AspNetCore.Mvc;

namespace ET.SchoolBus.Api.Middlewares;

public class SetSeasonMiddleware : IMiddleware
{
    private readonly ITenantManagerContext _tenantManagerContext;
    private readonly ApplicationUserContext _applicationUserContext;

    public SetSeasonMiddleware(ITenantManagerContext tenantManagerContext, ApplicationUserContext applicationUserContext)
    {
        _tenantManagerContext = tenantManagerContext;
        _applicationUserContext = applicationUserContext;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        int seasonId = _applicationUserContext.SeasonId;
        _tenantManagerContext.SetTenant(seasonId);

        await next(context);
    }
}
