namespace LmsClassLibrary.Model;

public class Direction
{
    public int DirectionId { get; set; }

    public string DirectionCode { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public string Details { get; set; } = null!;
}
