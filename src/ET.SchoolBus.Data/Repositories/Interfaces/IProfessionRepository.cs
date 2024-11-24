using System;
using ET.SchoolBus.Domain.Entities;

namespace ET.SchoolBus.Data.Repositories.Interfaces;

public interface IProfessionRepository : IGenericRepository<Profession>
{
    Task<bool> ProfessionExistsByNameOnCreate(string name);
    Task<bool> ProfessionExistsByNameOnUpdate(int id, string name);
}
