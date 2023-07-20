namespace ConsoleApp;

public interface IStack<T>
{
    void Push(T item);
    T Pop();
    T Peek();
    bool IsEmpty { get; }
}

public class IntStack : IStack<int>
{
    private List<int> items;

    public IntStack() => items = new List<int>();

    public void Push(int item) => items.Add(item);

    public int Pop() =>
        (items.Count == 0) ? throw new InvalidOperationException("Stack is empty.") : items[^1];

    public int Peek() =>
        (items.Count == 0) ? throw new InvalidOperationException("Stack is empty.") : items[^1];

    public bool IsEmpty => items.Count == 0;
}