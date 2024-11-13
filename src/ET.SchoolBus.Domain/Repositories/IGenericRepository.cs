using System;
using ET.SchoolBus.Domain.Common;

namespace ET.SchoolBus.Domain.Repositories;

public interface IGenericRepository<TEntity> : IDisposable where TEntity:BaseEntity
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);

    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    Task DeleteAsync(int id);
    void Delete(TEntity entity);    
}
