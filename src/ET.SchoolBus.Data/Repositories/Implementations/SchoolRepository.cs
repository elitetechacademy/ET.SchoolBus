using System;
using ET.SchoolBus.Data.Context;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ET.SchoolBus.Data.Repositories.Implementations;

public class SchoolRepository : GenericRepository<School>, ISchoolRepository
{
    private readonly SchoolBusContext _schoolBusContext;

    public SchoolRepository(SchoolBusContext schoolBusContext) : base(schoolBusContext)
    {
        _schoolBusContext = schoolBusContext;
    }

    public async Task<bool> SchoolExistsByNameOnCreate(string schoolName)
    {
        return await _schoolBusContext.Schools.AnyAsync(x => x.SchoolName == schoolName);
    }

    public async Task<bool> SchoolExistsByNameOnUpdate(int schoolId, string schoolName)
    {
        return await _schoolBusContext.Schools.AnyAsync(x => x.SchoolName == schoolName && x.SchoolId != schoolId);
    }
}
