using System.Reflection;
using ET.SchoolBus.Domain.Entities;
using ET.SchoolBus.Pack.AppContext;
using Microsoft.EntityFrameworkCore;

namespace ET.SchoolBus.Data.Context;

public class SchoolBusContext : DbContext
{
    private readonly int seasonId;
    public SchoolBusContext(DbContextOptions<SchoolBusContext> options, ApplicationUserContext applicationUserContext) : base(options)
    {
        seasonId = applicationUserContext.SeasonId;
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
    public DbSet<Season> Seasons { get; set; }
    


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
        modelBuilder.Entity<Season>().HasQueryFilter(x => x.Status);

        //Tenant işlemi için QueryFilter
        modelBuilder.Entity<Driver>().HasQueryFilter(x => x.SeasonId == seasonId);
        modelBuilder.Entity<Hostes>().HasQueryFilter(x => x.SeasonId == seasonId);
        modelBuilder.Entity<Parent>().HasQueryFilter(x => x.SeasonId == seasonId);
        modelBuilder.Entity<School>().HasQueryFilter(x => x.SeasonId == seasonId);
        modelBuilder.Entity<Student>().HasQueryFilter(x => x.SeasonId == seasonId);
        modelBuilder.Entity<Vehicle>().HasQueryFilter(x => x.SeasonId == seasonId);
        
        base.OnModelCreating(modelBuilder);
    }
}
