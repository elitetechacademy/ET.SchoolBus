using System;
using ET.SchoolBus.Domain.Entities;

namespace ET.SchoolBus.Data.Repositories.Interfaces;

public interface IParentRepository : IGenericRepository<Parent>
{
    Task<bool> ParentExistsByNameOnCreate(int SchoolId, string name, string surname);
    Task<bool> ParentExistsByNameOnUpdate(int parentId, int schoolId, string name, string surname);
    Task<List<Parent>> GetByProfessionIdAsync(int professionId);
    Task<List<Parent>> GetBySchoolIdAsync(int schoolId);
}
