using ET.SchoolBus.Data.Context;
using ET.SchoolBus.Data.Repositories.Implementations;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Domain.Common;
using ET.SchoolBus.Pack.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ET.SchoolBus.Data.UnitWork;

public class UnitOfWork : IUnitOfWork
{
    private bool disposed = false;
    private readonly SchoolBusContext _schoolBusContext;

    private readonly ApplicationUserContext _applicationUserContext;

    #region Repository Instances
    private IBrandRepository _brandRepository;
    private IModelRepository _modelRepository;
    private IApplicationUserRepository _applicationUserRepository;

    #endregion

    public UnitOfWork(SchoolBusContext schoolBusContext, ApplicationUserContext applicationUserContext)
    {
        _schoolBusContext = schoolBusContext;
        _applicationUserContext = applicationUserContext;
    }

    #region Repository Init

    public IBrandRepository BrandRepository
    {
        get
        {
            if (_brandRepository is null)
                _brandRepository = new BrandRepository(_schoolBusContext);
            return _brandRepository;
        }
    }

    public IModelRepository ModelRepository
    {
        get
        {
            if (_modelRepository is null)
                _modelRepository = new ModelRepository(_schoolBusContext);
            return _modelRepository;
        }
    }

    public IApplicationUserRepository ApplicationUserRepository
    {
        get
        {
            if (_applicationUserRepository is null)
                _applicationUserRepository = new ApplicationUserRepository(_schoolBusContext);
            return _applicationUserRepository;
        }
    }

    #endregion

    public IDbContextTransaction BeginTransaction()
    {
        return _schoolBusContext.Database.BeginTransaction();
    }

    public async Task<bool> Commit()
    {
        foreach (var entry in _schoolBusContext.ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedTime = DateTime.Now;
                    entry.Entity.CreatedUser = _applicationUserContext.Username ?? "admin";
                    entry.Entity.Status = true;
                    break;
                case EntityState.Deleted:
                    entry.Entity.UpdatedTime = DateTime.Now;
                    entry.Entity.UpdatedUser = _applicationUserContext.Username ?? "admin";
                    entry.Entity.Status = false;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedTime = DateTime.Now;
                    entry.Entity.UpdatedUser = _applicationUserContext.Username ?? "admin";
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
        if (disposed)
            return;

        if (disposing)
        {
            //Managed Resource
            _schoolBusContext.Dispose();
        }
        disposed = true;
    }
}
