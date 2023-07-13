using LmsClassLibrary.Interfaces;

namespace LmsClassLibrary.Model;

public record Submission : EntityWithId
{
    // public int Id { get; set; }
    public string Text { get; set; }
    public User User { get; set; }
    public Assignment Assignment { get; set; }

    public Submission()
    {
    }

    public Submission(int id, string text)
    {
        Id = id;
        Text = text;
    }

    public override string DisplayContent()
        => $"*This Submission:\r\nId: {Id}\r\nText: {Text}\r\nUser: {User}\r\nAssignment: {Assignment}";
    
    
    public override string DisplayContent(string someText)
        => $"*This Submission:\r\nId: {Id}\r\nText: {Text}\r\nUser: {User}\r\nAssignment: {Assignment}\r\nsomeText: {someText}";
}