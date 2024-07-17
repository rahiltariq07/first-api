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
    }
}
