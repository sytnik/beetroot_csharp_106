namespace LmsClassLibrary.Model;

public class Faculty
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string Info { get; set; } = null!;
}
