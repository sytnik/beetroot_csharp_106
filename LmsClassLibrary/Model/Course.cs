namespace LmsClassLibrary.Model;

public record Course : EntityWithIdAndName
{
    public string Description { get; set; } = "Default Description";
    public User Teacher { get; set; }
    public List<Module> Modules { get; set; } = new();
    public List<User> Students { get; set; } = new();

    public bool CourseEquals(Course course) =>
        Id == course.Id &&
        Name == course.Name &&
        Description == course.Description;
}