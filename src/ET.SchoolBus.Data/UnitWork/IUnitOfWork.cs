
using ET.SchoolBus.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace ET.SchoolBus.Data.UnitWork;

public interface IUnitOfWork : IDisposable
{
    IBrandRepository BrandRepository{get;}
    IModelRepository ModelRepository{get;}
    IDbContextTransaction BeginTransaction();
    Task<bool> Commit();
}
