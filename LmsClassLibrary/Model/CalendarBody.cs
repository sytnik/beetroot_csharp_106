namespace LmsClassLibrary.Model;

public class CalendarBody
{
    public int Id { get; set; }

    public int Term { get; set; }

    public int PartOne { get; set; }

    public int PartTwo { get; set; }

    public int YearId { get; set; }

    public int CalendarId { get; set; }
    public Year Year { get; set; }
    public Calendar Calendar { get; set; }
}
