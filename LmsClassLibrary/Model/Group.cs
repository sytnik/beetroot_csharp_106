namespace LmsClassLibrary.Model;

public class Group
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Course { get; set; }

    public int StudentCount { get; set; }

    public decimal Coefficient { get; set; }

    public decimal Finance { get; set; }

    public int StartYearId { get; set; }

    public int PropositionId { get; set; }

    public int CurrentYearId { get; set; }
    public Year StartYear { get; set; }
    public Year CurrentYear { get; set; }
    public Proposition Proposition { get; set; }
}