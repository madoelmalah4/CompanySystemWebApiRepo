using Microsoft.EntityFrameworkCore;

namespace CompanyManagmentSystem.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

       
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>(e =>
            {

                e.HasMany(emp => emp.Projects)
                .WithMany(a => a.Employees);
                ;

                e.HasOne(emp => emp.Contract)
                .WithOne(c => c.Employee)
                .HasForeignKey<Contract>(i => i.EmployeeId)
                .IsRequired(false);

                e.HasOne(emp => emp.Department)
                .WithMany(d => d.Employees);

            });

        }

    }
}
