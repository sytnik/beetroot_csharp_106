namespace LmsClassLibrary.Model;

public class Faculty
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public string Info { get; set; }
    public List<Department> Departments { get; set; }
}
