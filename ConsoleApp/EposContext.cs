using Microsoft.EntityFrameworkCore;

namespace ConsoleApp;

public class EposContext : DbContext
{
    public EposContext(DbContextOptions<EposContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calendar> Calendar { get; set; }

    public virtual DbSet<CalendarBody> CalendarBody { get; set; }

    public virtual DbSet<Cycle> Cycle { get; set; }

    public virtual DbSet<Degree> Degree { get; set; }

    public virtual DbSet<Department> Department { get; set; }

    public virtual DbSet<Direction> Direction { get; set; }

    public virtual DbSet<Discipline> Discipline { get; set; }
    public virtual DbSet<Faculty> Faculty { get; set; }

    public virtual DbSet<FullTime> FullTime { get; set; }

    public virtual DbSet<FullTimeVersion> FullTimeVersion { get; set; }

    public virtual DbSet<Group> Group { get; set; }

    public virtual DbSet<Plan> Plan { get; set; }

    public virtual DbSet<Programme> Programme { get; set; }

    public virtual DbSet<Proposition> Proposition { get; set; }

    public virtual DbSet<Speciality> Speciality { get; set; }

    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<Year> Year { get; set; }
}
