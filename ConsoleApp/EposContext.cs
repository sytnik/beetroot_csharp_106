using Microsoft.EntityFrameworkCore;

namespace ConsoleApp;

public class EposContext : DbContext
{
    public EposContext(DbContextOptions<EposContext> options)
        : base(options)
    {
    }

    public DbSet<Calendar> Calendar { get; set; }

    public DbSet<CalendarBody> CalendarBody { get; set; }

    public DbSet<Cycle> Cycle { get; set; }

    public DbSet<Degree> Degree { get; set; }

    public DbSet<Department> Department { get; set; }

    public DbSet<Direction> Direction { get; set; }

    public DbSet<Discipline> Discipline { get; set; }
    public DbSet<Faculty> Faculty { get; set; }

    public DbSet<FullTime> FullTime { get; set; }

    public DbSet<FullTimeVersion> FullTimeVersion { get; set; }

    public DbSet<Group> Group { get; set; }

    public DbSet<Plan> Plan { get; set; }

    public DbSet<Programme> Programme { get; set; }

    public DbSet<Proposition> Proposition { get; set; }

    public DbSet<Speciality> Speciality { get; set; }

    public DbSet<User> User { get; set; }

    public DbSet<Year> Year { get; set; }
}
