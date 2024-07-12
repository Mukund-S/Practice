using EntityFramework.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace EntityFramework.Infrastructure.Data;

//DB Context : Iquerable interface
public class EfDemoDbContext: DbContext
{
    //Properties of DbContext Class
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conn = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("EfDemoDb");
        optionsBuilder.UseSqlServer(conn);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Department>(entity =>
        // {
        //     entity.Property(e => e.DepartmentName).HasColumnType("varchar(20)");
        //     entity.HasKey(e => e.Id);
        //         entity.HasIndex(e => e.DepartmentName).IsUnique();
        // });
        modelBuilder.Entity<Department>(ConfigureDepartment);
    }

    private void ConfigureDepartment(EntityTypeBuilder<Department> builder)
    {
        builder.Property(e => e.DepartmentName).HasColumnType("varchar(20)");
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.DepartmentName).IsUnique();
    }
}