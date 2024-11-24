using System;
using ET.SchoolBus.Data.Context;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ET.SchoolBus.Data.Repositories.Implementations;

public class ProfessionRepository : GenericRepository<Profession>, IProfessionRepository
{
    private readonly SchoolBusContext _schoolBusContext;
    public ProfessionRepository(SchoolBusContext schoolBusContext) : base(schoolBusContext)
    {
        _schoolBusContext = schoolBusContext;
    }

    public async Task<bool> ProfessionExistsByNameOnCreate(string name)
    {
        return await _schoolBusContext.Professions.AnyAsync(x => x.Name == name);
    }

    public async Task<bool> ProfessionExistsByNameOnUpdate(int id, string name)
    {
        return await _schoolBusContext.Professions
            .AnyAsync(x => x.Name == name && x.ProfessionId != id);
    }
}
