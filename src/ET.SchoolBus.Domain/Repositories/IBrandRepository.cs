using System;
using ET.SchoolBus.Domain.Entities;

namespace ET.SchoolBus.Domain.Repositories;

public interface IBrandRepository : IGenericRepository<Brand>
{
    Task<bool> BrandExistsByNameOnCreate(string brandName);
    Task<bool> BrandExistsByNameOnUpdate(int brandId, string brandName);
}
