namespace LmsClassLibrary.Model;

public class Department
{
    public Department(int id, int number, string name)
    {
        Id = id;
        Number = number;
        Name = name;
    }

    public Department()
    {
    }

    public int Id { get; set; }

    public int Number { get; set; }

    public string Name { get; set; }

    public string Slug { get; set; }

    public string Info { get; set; }

    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
    public List<Proposition> Propositions { get; set; }

    public static void PrintData(int id, int number, string name)
    {
        Console.WriteLine($"Id: {id}, Name: {name}, Number: {number}");
    }
}