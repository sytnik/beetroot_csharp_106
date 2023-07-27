namespace LmsClassLibrary.Model;

public class Cycle
{
    public int Id { get; set; }

    public string Type { get; set; }

    public string Name { get; set; }

    public int DegreeId { get; set; }
    public Degree Degree { get; set; }
}
