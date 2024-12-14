using System;
using ET.SchoolBus.Domain.Entities;

namespace ET.SchoolBus.Data.Repositories.Interfaces;

public interface ISeasonRepository : IGenericRepository<Season>
{
    Task<bool> SeasonExistsByNameOnCreate(string name);
    Task<bool> SeasonExistsByNameOnUpdate(int SeasonId, string name);
}
