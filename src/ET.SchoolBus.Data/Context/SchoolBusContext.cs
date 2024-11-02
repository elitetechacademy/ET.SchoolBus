using System;
using ET.SchoolBus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ET.SchoolBus.Data.Context;

public class SchoolBusContext : DbContext
{
    public SchoolBusContext(DbContextOptions<SchoolBusContext> options) : base(options)
    {
        
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Hostes> Hosteses { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Profession> Professions { get; set; }
    public DbSet<School> Schools { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentParent> StudentParents { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
}
