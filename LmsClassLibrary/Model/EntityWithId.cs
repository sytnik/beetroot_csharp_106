using LmsClassLibrary.Interfaces;

namespace LmsClassLibrary.Model;

public record EntityWithId : IPrintable
{
    public EntityWithId()
    {
    }

    public EntityWithId(int id) => Id = id;

    public int Id { get; set; } = 1;

    public virtual string DisplayContent() =>
        $"*This EntityWithId:\r\nId: {Id}";
    
    public virtual string DisplayContent(string someText) =>
        $"*This EntityWithId:\r\nId: {Id}, someText: {someText}";
}