using System;
using ET.SchoolBus.Data.Context;
using ET.SchoolBus.Domain.Entities;
using ET.SchoolBus.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ET.SchoolBus.Data.Repositories;

public class BrandRepository : GenericRepository<Brand>, IBrandRepository
{
    private readonly SchoolBusContext _schoolBusContext;

    public BrandRepository(SchoolBusContext schoolBusContext) : base(schoolBusContext)
    {
        _schoolBusContext = schoolBusContext;
    }

    public async Task<List<Brand>> GetDeletedBrandsAsync()
    {
        return await _schoolBusContext.Brands.Where(x => !x.Status).ToListAsync();
    }
}
