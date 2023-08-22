namespace LmsClassLibrary.Model;

public record Faculty
{
    public Faculty(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }

    public int Number { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; } = "";

    public string Info { get; set; } = "";
    public IEnumerable<Department> Departments { get; set; }
}
