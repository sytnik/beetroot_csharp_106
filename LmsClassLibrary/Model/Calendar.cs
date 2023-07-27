namespace LmsClassLibrary.Model;

public class Calendar
{
    public int Id { get; set; }

    public string Span { get; set; }

    public string Type { get; set; }

    public string Student { get; set; }

    public string Language { get; set; }

    public string Enrollment { get; set; }

    public string Company { get; set; }

    public int YearId { get; set; }

    public int DegreeId { get; set; }
    public Year Year { get; set; }
    public Degree Degree { get; set; }
}