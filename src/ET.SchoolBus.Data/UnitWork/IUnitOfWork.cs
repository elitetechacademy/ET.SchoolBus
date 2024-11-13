using System;
using ET.SchoolBus.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace ET.SchoolBus.Data.UnitWork;

public interface IUnitOfWork : IDisposable
{
    IBrandRepository BrandRepository{get;}
    IDbContextTransaction BeginTransaction();
    Task<bool> Commit();
}
