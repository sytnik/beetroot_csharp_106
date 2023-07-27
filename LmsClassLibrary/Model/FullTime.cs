namespace LmsClassLibrary.Model;

public class FullTime
{
    public int Id { get; set; }

    public int PlanId { get; set; }
    public Plan Plan { get; set; }
}
