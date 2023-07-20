namespace LmsClassLibrary.Model;

public class Plan
{
    public int Id { get; set; }

    public DateTime Effective { get; set; }

    public string Name { get; set; } = null!;

    public int YearId { get; set; }

    public int PropositionId { get; set; }

    public int CalendarId { get; set; }
}
