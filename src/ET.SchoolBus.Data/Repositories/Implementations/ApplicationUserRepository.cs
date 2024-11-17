using System;
using ET.SchoolBus.Data.Context;
using ET.SchoolBus.Data.Repositories.Interfaces;
using ET.SchoolBus.Domain.Entities;
using ET.SchoolBus.Integration.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ET.SchoolBus.Data.Repositories.Implementations;

public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
{
    private readonly SchoolBusContext _schoolBusContext;

    public ApplicationUserRepository(SchoolBusContext schoolBusContext) : base(schoolBusContext)
    {
        _schoolBusContext = schoolBusContext;
    }

    public async Task<ApplicationUser> GetApplicationUserByUsernameAndPassword(string username, string password)
    {
        var user = await _schoolBusContext.ApplicationUsers.Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.UserName == username && x.Password == password && 
                x.Status && !x.IsLocked);
        return user;
    }
}
