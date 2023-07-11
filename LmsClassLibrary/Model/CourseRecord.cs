namespace LmsClassLibrary.Model;

public record CourseRecord
{
    public int Id { get; set; } = 1;
    public string Name { get; set; } = "Default Name";
    public string Description { get; set; } = "Default Description";
}