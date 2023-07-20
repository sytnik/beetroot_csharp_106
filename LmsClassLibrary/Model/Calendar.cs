namespace LmsClassLibrary.Model;

public class Calendar
{
    public int Id { get; set; }

    public string Span { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Student { get; set; } = null!;

    public string Language { get; set; } = null!;

    public string Enrollment { get; set; } = null!;

    public string Company { get; set; } = null!;

    public int YearId { get; set; }

    public int DegreeId { get; set; }
}
