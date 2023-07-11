namespace LmsClassLibrary.Model;

public record Module
{
    public int Id { get; set; } = 1;
    public string Name { get; set; } = "Default module";
    public Course Course { get; set; }
    public List<Assignment> Assignments { get; set; } = new();
}