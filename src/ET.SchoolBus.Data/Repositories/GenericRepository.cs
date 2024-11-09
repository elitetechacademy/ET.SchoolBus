using System;
using ET.SchoolBus.Data.Context;
using ET.SchoolBus.Domain.Common;
using ET.SchoolBus.Domain.CustomException;
using ET.SchoolBus.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ET.SchoolBus.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    private bool disposed = false;
    private readonly SchoolBusContext _schoolBusContext;
    protected readonly DbSet<TEntity> DbSet;

    public GenericRepository(SchoolBusContext schoolBusContext)
    {
        _schoolBusContext = schoolBusContext;
        DbSet = _schoolBusContext.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetAllActiveAsync()
    {
        return await DbSet.Where(x => x.Status).ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity is not null)
            return entity;
        else
            throw new NotFoundException($"{id} nolu kayıt bulunamadı.");
    }


    public async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity is not null)
            DbSet.Remove(entity);
        else
            throw new NotFoundException($"{id} nolu kayıt bulunamadı.");
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;

        //Unmanaged Resource
        //Harici kütüphaneler (işletim sistemi tarafından yönetilen kodlar)
        //Windows api veya C++ ile yazılmış ve uygulamaızda kullandığımız bir kütüphane
        if (disposing)
        {
            //Managed Resource (Kullandığımız ve .Net tarafından yönetilen kodlar)
            _schoolBusContext.Dispose();
        }
        disposed = true;
    }
}
