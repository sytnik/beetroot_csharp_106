namespace LmsClassLibrary.Model;

public record Course
{
    public int Id { get; set; } = 1;
    public string Name { get; set; } = "Default Name";
    public string Description { get; set; } = "Default Description";
    public User Teacher { get; set; }
    public List<Module> Modules { get; set; } = new();
    public List<User> Students { get; set; } = new();

    public bool CourseEquals(Course course) =>
        Id == course.Id &&
        Name == course.Name &&
        Description == course.Description;
}