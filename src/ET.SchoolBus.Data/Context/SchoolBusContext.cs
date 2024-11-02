using System;
using Microsoft.EntityFrameworkCore;

namespace ET.SchoolBus.Data.Context;

public class SchoolBusContext : DbContext
{
    public SchoolBusContext(DbContextOptions<SchoolBusContext> options) : base(options)
    {
        
    }

    
}
