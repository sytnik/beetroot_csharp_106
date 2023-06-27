class Program
{
    private int SomeClassValue = 5;

    static string ConcatOutput(string title, int val = 1, params string[] words)
    {
        string head = title + ": ";
        foreach (var word in words) head += word + ", ";
        return head;
    }

    static string PrintValue(int val, string str, out int res, ref int someValue, int opt = 1)
    {
        var result = "Some value " + val + str + opt;
        Console.WriteLine(result);
        val = val + 1;
        someValue = opt + someValue + 2;
        res = opt + 1;
        return res > 5 ? result : "";
    }

    static string PrintValue(int val, string str, out int res, ref int someValue,
        double nextValue, int opt = 1)
    {
        var result = "Some value " + val + str + opt;
        Console.WriteLine(result);
        val = val + 1;
        someValue = opt + someValue + 2;
        res = opt + 1;
        return res > 5 ? result : "";
    }

    static int Sum(int from, int to)
    {
        // var local = SomeClassValue;
        if (from > to) return Sum(to, from);
        if (from == to) return from;
        return from + Sum(from + 1, to);
    }

    static int SumFor(int from, int to)
    {
        var result = 0;
        for (var i = from; i <= to; i++)
        {
            result += i;
        }

        return result;
    }

    static void PrintValueShort() => Console.WriteLine("Some value");

    static unsafe void Pointers()
    {
        int x = 42;
        int* p = &x;
        Console.WriteLine("Value of x: " + x);
        Console.WriteLine("Value stored in the pointer p: " + *p);
        *p = 24; // Modifying the value indirectly through the pointer
        Console.WriteLine("New value of x: " + x);
    }

    static void Main()
    {
        Pointers();
        int val1 = 1;
        object boxed = val1; // boxing
        val1 = (int) boxed; // unboxing
        int? val = null;
        // var test = val.Value;
        int notNull = 0;
        var copy = val.HasValue ? val.Value : 0;
        var copy1 = val ?? 5;
        var copy2 = notNull != 0 ? notNull : 7;
        Console.WriteLine("Input some int...");
        var stringInput = Console.ReadLine();
        // var int1 = Convert.ToInt32(stringInput);
        if (int.TryParse(stringInput, out var int1))
            Console.WriteLine($"Input was valid, {int1}");
        else Console.WriteLine("Input was not valid");
        var title = "title";
        var concat1 = ConcatOutput(title);
        var concat2 = ConcatOutput("title", 1, "w1", "w2", "w3", "w4");
        Sum(5, 10);
        SumFor(5, 10);
        int i = 0;
        var someNonRef = 5;
        var intermediate = 1;
        var result = PrintValue(someNonRef, str: "string", out var x, ref intermediate, 5);
        var result2 =
            PrintValue(someNonRef, str: "string", out var y, ref intermediate, 5, 5);
        Console.WriteLine(x);
        PrintValueShort();
        // for (int i = 0; i < 5; i++)
        // {
        //     Console.Write($"Iteration {i}: "); // виводиться завжди
        //     if (i < 3)
        //     {
        //         Console.WriteLine("skip");
        //         continue; // при 0, 1, 2 робимо пропуск наступного рядку
        //     }
        //     Console.WriteLine("done"); // при 3, 4 виводимо done
        // }
        //
        // var str = "qwerty";
        // foreach (int ch in str)
        // {
        //     if (ch == 'r') 
        //     { // в кейсі літери ‘r’ виходимо з циклу
        //         break;
        //     }
        //     Console.Write($"{ch}"); // ‘q’,’w’,’e’
        // }

        // while
        // int i = 0;
        // while (i < 5) // while умова true
        // {
        //     Console.WriteLine(i);         // тіло циклу
        //     i++;			//
        // }
        //
        // // do while
        // i = 0;
        // do 
        // {
        //     Console.WriteLine(i++); // перша ітерація виконається
        // }
        // while (i < 5);

        // var str = "qwerty";
        // foreach (var ch in str)
        // {
        //     Console.Write(str.IndexOf(ch));  
        // } // ‘qwerty’

        // var str = "qwerty";
        //
        // // for (ініціалізація; умова; інкремент)
        // for (var i = 0; i < str.Length; i++)
        // {
        //     Console.Write(str[i]);
        // } // ‘qwerty’
        //
        // // foreach (type variable in collection)
        // foreach (var ch in str)
        // {
        //     Console.Write(ch);  
        // } // ‘qwerty’

        // int v;
        // int a = int.Parse(Console.ReadLine());
        // // string a, b;
        // int b;
        // if (a == 1)
        // {
        //     b = 10;
        // }
        // else
        // {
        //     b = 15;
        // }
        //
        // b = a == 1
        //     ? 10 // true
        //     : 15; // false


        // v = int.Parse(Console.ReadLine());
        // switch (v)
        // {
        //     case < 10:
        //         a = "beforeTen";
        //         break;
        //     case 10:
        //         a = "isTen";
        //         break;
        //     case > 10 and < 100 or > 1000:
        //         a = "afterTen";
        //         break;
        //     default:
        //         a = "smth else";
        //         break;
        // }
        //
        // // switch expression
        // a = v switch
        // {
        //     < 10 => "beforeTen",
        //     10 => "isTen",
        //     > 10 and < 100 => "afterTen",
        //     _ => "smth else"
        // };
        //
        // Console.WriteLine(a);


        // b = Console.ReadLine();
        // bool boolCondition = a == "true";
        // bool anotherCondition = b == "true";
        // if (boolCondition && anotherCondition) 
        // {
        //     Console.WriteLine("boolCondition is true");
        // }
        // else if (anotherCondition) 
        // {
        //     Console.WriteLine("boolCondition is not true, but anotherCondition is true");
        // }
        // else
        // {
        //     Console.WriteLine("boolCondition is not true, and anotherCondition is not true");
        // }
    }
}

// Console.WriteLine("Hello, World!");

// testfunc();
//
// static void testfunc()
// {
//     int i = 0;
// }