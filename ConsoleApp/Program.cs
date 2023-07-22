namespace ConsoleApp;

public class Program
{
    public static void Swap<T>(ref T val1, ref T val2) where T : class
    {
        T temp = val1;
        val1 = val2;
        val2 = temp;
    }


    public static void PrintGenericCollection<T>(IEnumerable<T> src) =>
        Console.WriteLine(string.Join(", ", src));

    public static IEnumerable<T> MakeCollectionFromParams<T>(params T[] src) =>
        new List<T>(src);

    public static void Main(string[] args)
    {
        var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        list.Add(1);
        list.AddRange(list);
        list.Remove(1);
        list.RemoveAt(0);
        list.RemoveRange(0, 2);
        list.RemoveAll(x => x > 4);
        var contains = list.Contains(1);

        // var dict1 = new Dictionary<int, string>();
        // dict1.Add(1, "one");
        // dict1.Add(2, "two");
        // dict1.Add(3, "three");
        var dict = new Dictionary<int, string>
        {
            {1, "one"},
            {2, "two"},
            {3, "three"}
        };
        var containsKey = dict.ContainsKey(1);
        var containsValue = dict.ContainsValue("one");
        var keys = dict.Keys;
        var values = dict.Values;
        var count = dict.Count;
        dict.Remove(1);
        dict.Add(4, "four");
        var try1 = dict.TryAdd(5, "five");
        var try2 = dict.TryAdd(5, "five");
        var tryval = dict.TryGetValue(5, out var val);
        var tryval1 = dict.TryGetValue(7, out var val1);
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        var dequeue = queue.Dequeue();
        var peek = queue.Peek();
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        var pop = stack.Pop();
        var peek1 = stack.Peek();
        var hashset = new HashSet<int>
        {
            1,
            2,
            3,
            4,
            5,
            6
        };
        var hashset1 = new HashSet<int>
        {
            4,
            5,
            6,
            7,
            8,
            9
        };
        var intersect = hashset.Intersect(hashset1).ToHashSet();
        // hashset.IntersectWith(hashset1);
        var union = hashset.Union(hashset1).ToHashSet();
        // hashset.UnionWith(hashset1);
        var except = hashset.Except(hashset1).ToList();
        hashset.ExceptWith(hashset1);
        var contains1 = hashset.Contains(1);
        var contains2 = hashset.Contains(4);
        var count1 = hashset.Count;

        var linkedList = new LinkedList<int>();
        linkedList.AddFirst(1);
        linkedList.AddLast(2);
        linkedList.AddLast(3);
        linkedList.AddFirst(11);
        linkedList.AddLast(4);
        linkedList.AddLast(5);
        linkedList.AddAfter(linkedList.Find(3), 10);
        linkedList.AddBefore(linkedList.Find(3), 20);
        linkedList.Remove(3);
        linkedList.RemoveFirst();
        linkedList.RemoveLast();
        linkedList.Remove(11);
        
    }
}