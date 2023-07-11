namespace ConsoleApp;

public class Singleton
{
    public int Id { get; set; } = 1;

    public Singleton()
    {
    }

    public static Singleton Instance { get; } = new();
}