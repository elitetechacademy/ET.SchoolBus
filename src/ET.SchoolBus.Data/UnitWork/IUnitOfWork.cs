using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace ET.SchoolBus.Data.UnitWork;

public interface IUnitOfWork : IDisposable
{
    IDbContextTransaction BeginTransaction();
    Task<bool> Commit();
}
