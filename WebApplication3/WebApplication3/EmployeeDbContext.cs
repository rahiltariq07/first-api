using Microsoft.EntityFrameworkCore;
using WebApplication3.Entities;

namespace WebApplication3
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data in the Department Table
            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 1,
                Name = "IT"
            });
            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 2,
                Name = "Sales"
            });
            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 3,
                Name = "Marketing"
            });
            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 4,
                Name = "R & D"
            });
        }
    }
}
