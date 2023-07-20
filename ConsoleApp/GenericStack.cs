namespace ConsoleApp;

public class GenericStack<T>
{
    private List<T> items;
    
    public GenericStack() => items = new List<T>();
    
    public void Push(T item) => items.Add(item);

    public T Pop()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Stack is empty.");
        T item = items[^1];
        items.RemoveAt(items.Count - 1);
        return item;
    }

    public T Peek()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Stack is empty.");
        return items[^1];
    }

    public bool IsEmpty() => items.Count == 0;
}
