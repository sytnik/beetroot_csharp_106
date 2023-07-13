using LmsClassLibrary.Interfaces;

namespace LmsClassLibrary.Model;

public record EntityWithIdAndName : EntityWithId
{
    public EntityWithIdAndName(int id, string name) : base(id) => Name = name;

    public EntityWithIdAndName(string name)
    {
        Name = name;
    }

    public EntityWithIdAndName()
    {
    }

    public string Name { get; set; } = "Default Name";
}