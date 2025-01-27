using System;
using ET.SchoolBus.Data.Context;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ET.SchoolBus.Data.Repositories.Implementations;

public class ModelRepository : GenericRepository<Model>, IModelRepository
{
    private readonly SchoolBusContext _schoolBusContext;
    public ModelRepository(SchoolBusContext schoolBusContext):base(schoolBusContext)
    {
        _schoolBusContext = schoolBusContext;
    }

    public async Task<List<Model>> GetAllWithBrandAsync()
    {
        return await _schoolBusContext.Models.Include(x => x.Brand).ToListAsync();
    }

    public async Task<Model?> GetByIdWithBrandAsync(int id)
    {
        return await _schoolBusContext.Models.Include(x => x.Brand).FirstOrDefaultAsync(x => x.ModelId == id);
    }

    public async Task<bool> ModelExistsByNameOnCreate(int brandId, string modelName)
    {
        return await _schoolBusContext.Models.AnyAsync(x => x.BrandId == brandId &&
            x.ModelName == modelName);
    }

    public async Task<bool> ModelExistsByNameOnUpdate(int modelId, int brandId, string modelName)
    {
        return await _schoolBusContext.Models.AnyAsync(x => x.BrandId == brandId &&
            x.ModelName == modelName && x.ModelId != modelId);
    }

    public async Task<List<Model>> GetByBrandIdAsync(int brandId)
    {
        return await _schoolBusContext.Models.Where(x => x.BrandId == brandId).ToListAsync();
    }
}
