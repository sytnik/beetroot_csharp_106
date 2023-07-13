namespace LmsClassLibrary.Model;

public record Assignment : EntityWithIdAndName
{
    // public int Id { get; set; }
    // public string Name { get; set; }
    public Module Module { get; set; }
    public List<Submission> Submissions { get; set; } = new();

    public Assignment(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Assignment()
    {
    }
}