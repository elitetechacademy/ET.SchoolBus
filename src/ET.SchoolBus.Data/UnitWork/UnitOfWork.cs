using System;
using ET.SchoolBus.Data.Context;
using ET.SchoolBus.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ET.SchoolBus.Data.UnitWork;

public class UnitOfWork : IUnitOfWork
{
    private bool disposed = false;
    private readonly SchoolBusContext _schoolBusContext;

    public UnitOfWork(SchoolBusContext schoolBusContext)
    {
        _schoolBusContext = schoolBusContext;
    }

    public IDbContextTransaction BeginTransaction()
    {
        return _schoolBusContext.Database.BeginTransaction();
    }

    public async Task<bool> Commit()
    {
        foreach(var entry in _schoolBusContext.ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedTime = DateTime.Now;
                    entry.Entity.CreatedUser = "admin";
                    entry.Entity.Status = true;
                    break;
                case EntityState.Deleted:
                    entry.Entity.UpdatedTime = DateTime.Now;
                    entry.Entity.UpdatedUser = "admin";
                    entry.Entity.Status = false;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedTime = DateTime.Now;
                    entry.Entity.UpdatedUser = "admin";
                    break;      
                default:
                    break;              
            }
        }

        return await _schoolBusContext.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public virtual void Dispose(bool disposing)
    {
        if(disposed)
            return;

        if(disposing)
        {
            //Managed Resource
            _schoolBusContext.Dispose();
        }
        disposed = true;
    }
}
