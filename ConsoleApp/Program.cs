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
        var baseClass = new BaseClass {Id = 1};
        var derivedClass = new DerivedClass {Id = 2, Name = "Name"};
        var baseList = new List<BaseClass> {baseClass, derivedClass};
        var elemId = baseList[1].Id;
        var name = ((DerivedClass) baseList[1]).Name;
        var equal = derivedClass.Equals(derivedClass);
        // var comapare = derivedClass.Compare(baseClass, derivedClass);
        var derivedList = new List<DerivedClass>
            {new DerivedClass {Id = 1, Name = "Name1"},
                new DerivedClass {Id = 2, Name = "Name2"}};
        var derivedReverse =
            derivedList.OrderByDescending(e => e.Id);
        IEnumerable<int> ein = MakeCollectionFromParams(1, 2, 3);
        PrintGenericCollection(new List<int> {1, 2, 3});
        PrintGenericCollection(new[] {"1", "2", 3.ToString()});
        int num1 = 1, num2 = 2;
        string str1 = "str1", str2 = "str2";
        // Swap(ref num1, ref num2);
        Swap(ref str1, ref str2);
        var stack = new GenericStack<int>();
        stack.Push(1);
        stack.Push(2);
        var value = stack.Pop();
        var strStack = new GenericStack<string>();
        strStack.Push("str1");
        strStack.Push("str2");
        var strValue = strStack.Pop();

        Console.ReadKey();
    }
}