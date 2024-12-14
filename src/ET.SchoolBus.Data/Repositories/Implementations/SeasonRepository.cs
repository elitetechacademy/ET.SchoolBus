using System;
using ET.SchoolBus.Data.Context;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ET.SchoolBus.Data.Repositories.Implementations;

public class SeasonRepository : GenericRepository<Season>, ISeasonRepository
{
    private readonly SchoolBusContext _schoolBusContext;

    public SeasonRepository(SchoolBusContext schoolBusContext) : base(schoolBusContext)
    {
        _schoolBusContext = schoolBusContext;
    }

    public async Task<bool> SeasonExistsByNameOnCreate(string name)
    {
        return await _schoolBusContext.Seasons.AnyAsync(x => x.Name == name);
    }

    public async Task<bool> SeasonExistsByNameOnUpdate(int seasonId, string name)
    {
        return await _schoolBusContext.Seasons.AnyAsync(x => x.Name == name && x.SeasonId != seasonId);
    }
}
