namespace ConsoleApp;

public class Example
{
    public void DoSomething(Action action)
    {
        // Зробити щось тут...
        action();
    }
}

public class Subscriber
{
    public void HandleAction()
    {
        Console.WriteLine("Action handled!");
    }
}
