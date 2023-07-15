namespace LmsClassLibrary.Model;

public record Submission : EntityWithId
{
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

    public string DisplayContent()
        => $"*This Submission:\r\nId: {Id}\r\nText: {Text}\r\nUser: {User}\r\nAssignment: {Assignment}";
    
    
    public string DisplayContent(string someText)
        => $"*This Submission:\r\nId: {Id}\r\nText: {Text}\r\nUser: {User}\r\nAssignment: {Assignment}\r\nsomeText: {someText}";
}