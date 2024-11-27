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
    private IProfessionRepository _professionRepository;

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

    public IProfessionRepository ProfessionRepository
    {
        get
        {
            if (_professionRepository is null)
                _professionRepository = new ProfessionRepository(_schoolBusContext);
            return _professionRepository;
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
                    SetAddedState(entry.Entity);

                    break;
                case EntityState.Deleted:
                    entry.Entity.UpdatedTime = DateTime.Now;
                    entry.Entity.UpdatedUser = _applicationUserContext.Username ?? "admin";
                    entry.Entity.Status = false;
                    break;
                case EntityState.Modified:
                    SetModifiedState(entry.Entity);
                    break;
                default:
                    break;
            }
        }

        return await _schoolBusContext.SaveChangesAsync() > 0;
    }


    private void SetAddedState(BaseEntity entity)
    {
        if (entity is not null)
            return;

        //BaseEntity için ayarlamalar
        entity.CreatedTime = DateTime.Now;
        entity.CreatedUser = _applicationUserContext.Username ?? "admin";
        entity.Status = true;

        //Tenant için gerekli
        if(entity is ITenantEntity tenantEntity)
        {
            if (tenantEntity is not null)
                tenantEntity.SeasonId = _applicationUserContext.SeasonId;
        }        
    }

    private void SetModifiedState(BaseEntity entity)
    {
        if (entity is not null)
            return;

        //BaseEntity için ayarlamalar
        entity.UpdatedTime = DateTime.Now;
        entity.UpdatedUser = _applicationUserContext.Username ?? "admin";
        entity.Status = true;

        //Tenant için gerekli
        if(entity is ITenantEntity tenantEntity)
        {
            if (tenantEntity is not null)
                tenantEntity.SeasonId = _applicationUserContext.SeasonId;
        }        
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
