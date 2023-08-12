using Microsoft.EntityFrameworkCore;

namespace ConsoleApp;

public class TestAppContext : DbContext
{
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Department> Departments { get; set; }
    
    public TestAppContext(DbContextOptions<TestAppContext> options) : base(options)
    {
    }
   
}