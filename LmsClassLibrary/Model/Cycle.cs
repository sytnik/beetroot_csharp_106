namespace LmsClassLibrary.Model;

public class Cycle
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int DegreeId { get; set; }
}
