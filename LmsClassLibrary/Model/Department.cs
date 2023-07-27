namespace LmsClassLibrary.Model;

public class Department
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public string Info { get; set; }

    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
    public List<Proposition> Propositions { get; set; }
}
