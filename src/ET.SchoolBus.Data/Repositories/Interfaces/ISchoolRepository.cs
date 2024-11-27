using System;
using ET.SchoolBus.Domain.Entities;

namespace ET.SchoolBus.Data.Repositories.Interfaces;

public interface ISchoolRepository : IGenericRepository<School>
{
    Task<bool> SchoolExistsByNameOnCreate(string schoolName);
    Task<bool> SchoolExistsByNameOnUpdate(int schoolId, string schoolName);
}
