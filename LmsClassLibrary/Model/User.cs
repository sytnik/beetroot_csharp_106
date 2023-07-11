namespace LmsClassLibrary.Model;

public class User
{
    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public const int IdIncrement = 1;
    public readonly Guid SystemGuid = Guid.NewGuid();
    public int Id { get; set; } = 1;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; } = "default@mail.com";
    public string Password { get; set; }
    public List<Course> Courses { get; set; } = new();

    public User()
    {
    }

    public User(int id, string email, string password)
    {
        Id = id;
        Email = email;
        Password = password;
    }

    public User(int id, string firstName, string lastName, string email, string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }


    public string GetFullName() =>
        $"{FirstName} {LastName}";

    public static string
        GetFullNameStatic(string firstName,
            string lastName) =>
        $"{firstName} {lastName}";
}