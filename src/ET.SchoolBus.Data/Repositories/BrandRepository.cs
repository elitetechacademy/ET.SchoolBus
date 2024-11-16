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

    public async Task<bool> BrandExistsByNameOnCreate(string brandName)
    {
        return await _schoolBusContext.Brands.AnyAsync(x => x.BrandName == brandName);
    }

    public async Task<bool> BrandExistsByNameOnUpdate(int brandId, string brandName)
    {
        return await _schoolBusContext.Brands.AnyAsync(x => x.BrandName == brandName && x.BrandId != brandId);
    }
}
