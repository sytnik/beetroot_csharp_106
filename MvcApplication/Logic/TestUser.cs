namespace MvcApplication.Logic;

public class TestUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }

    public TestUser()
    {
    }
    public TestUser(int id, string name, DateTime date)
    {
        Id = id;
        Name = name;
        Date = date;
    }
}