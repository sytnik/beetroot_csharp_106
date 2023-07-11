namespace LmsClassLibrary.Model;

public record Submission
{
    public int Id { get; set; }
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
}