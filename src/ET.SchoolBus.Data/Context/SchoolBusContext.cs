using System;
using System.Linq.Expressions;
using System.Reflection;
using ET.SchoolBus.Data.Extensions;
using ET.SchoolBus.Data.Mappings;
using ET.SchoolBus.Domain.Common;
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
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Role> Roles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //QueryFilters
        //modelBuilder.ApplySoftDeleteFilter<BaseEntity>();

        //Soft delete için query filter ayarlanıyor
        modelBuilder.Entity<ApplicationUser>().HasQueryFilter(x => x.Status);
        modelBuilder.Entity<Brand>().HasQueryFilter(x => x.Status);
        modelBuilder.Entity<Driver>().HasQueryFilter(x => x.Status);
        modelBuilder.Entity<Hostes>().HasQueryFilter(x => x.Status);
        modelBuilder.Entity<Model>().HasQueryFilter(x => x.Status);
        modelBuilder.Entity<Parent>().HasQueryFilter(x => x.Status);
        modelBuilder.Entity<Profession>().HasQueryFilter(x => x.Status);
        modelBuilder.Entity<Role>().HasQueryFilter(x => x.Status);
        modelBuilder.Entity<School>().HasQueryFilter(x => x.Status);
        modelBuilder.Entity<Student>().HasQueryFilter(x => x.Status);
        modelBuilder.Entity<StudentParent>().HasQueryFilter(x => x.Status);
        modelBuilder.Entity<Vehicle>().HasQueryFilter(x => x.Status);
        
        base.OnModelCreating(modelBuilder);
    }
}
