using System;
using ET.SchoolBus.Domain.Entities;

namespace ET.SchoolBus.Data.Repositories.Interfaces;

public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
{
    Task<ApplicationUser> GetApplicationUserByUsernameAndPassword(string username, string password);
}
