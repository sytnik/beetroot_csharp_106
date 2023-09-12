using System.ComponentModel.DataAnnotations;

namespace MvcApplication.Logic;

public static class AuthMock
{
    public static List<MockUser> Users { get; set; } = new()
    {
        new MockUser
        {
            Id = "1",
            Login = "admin",
            Password = "admin",
            Role = "Admin"
        },
        new MockUser
        {
            Id = "2",
            Login = "user",
            Password = "user",
            Role = "User"
        }
    };
}

public class MockUser
{
    public string Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}

public record MockUserDto
{
    [Required, MinLength(3)]
    public string Login { get; set; }
    [Required, MinLength(3)]
    public string Password { get; set; }
    public string ReturnUrl { get; set; }
}