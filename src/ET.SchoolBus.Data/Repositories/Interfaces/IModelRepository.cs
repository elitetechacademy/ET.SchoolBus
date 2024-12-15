using System;
using ET.SchoolBus.Domain.Entities;

namespace ET.SchoolBus.Data.Repositories.Interfaces;

public interface IModelRepository : IGenericRepository<Model>
{
    Task<List<Model>> GetAllWithBrandAsync();
    Task<Model?> GetByIdWithBrandAsync(int id);
    Task<bool> ModelExistsByNameOnCreate(int brandId, string modelName);
    Task<bool> ModelExistsByNameOnUpdate(int modelId, int brandId, string modelName);
    Task<List<Model>> GetByBrandIdAsync(int brandId);
}
