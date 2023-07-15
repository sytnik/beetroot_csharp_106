namespace LmsClassLibrary.Model;

public record Assignment : EntityWithIdAndName
{
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