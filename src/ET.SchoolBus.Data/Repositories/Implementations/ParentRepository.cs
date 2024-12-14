using System;
using ET.SchoolBus.Data.Context;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ET.SchoolBus.Data.Repositories.Implementations;

public class ParentRepository : GenericRepository<Parent>, IParentRepository
{
    private readonly SchoolBusContext _schoolBusContext;
    public ParentRepository(SchoolBusContext schoolBusContext) : base(schoolBusContext)
    {
        _schoolBusContext = schoolBusContext;
    }

    public async Task<bool> ParentExistsByNameOnCreate(int SchoolId, string name, string surname)
    {
        return await _schoolBusContext.Parents.AnyAsync(x => x.Name == name && x.Surname == surname);
    }

    public async Task<bool> ParentExistsByNameOnUpdate(int parentId, int schoolId, string name, string surname)
    {
        return await _schoolBusContext.Parents
            .AnyAsync(x => x.Name == name && x.Surname == surname && x.ParentId != parentId);
    }

    public async Task<List<Parent>> GetByProfessionIdAsync(int professionId)
    {
        return await _schoolBusContext.Parents.Where(x => x.ProfessionId == professionId).ToListAsync();
    }

    public async Task<List<Parent>> GetBySchoolIdAsync(int schoolId)
    {
        return await _schoolBusContext.Parents.Where(x=>x.SchoolId == schoolId).ToListAsync();
    }
}
