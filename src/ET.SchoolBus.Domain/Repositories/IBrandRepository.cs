using System;
using ET.SchoolBus.Domain.Entities;

namespace ET.SchoolBus.Domain.Repositories;

public interface IBrandRepository : IGenericRepository<Brand>
{
    Task<List<Brand>> GetDeletedBrandsAsync();
}
