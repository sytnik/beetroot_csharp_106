class Program
{
    static void PrintValue(int val, string str, out int res, int opt = 1)
    {
        Console.WriteLine("Some value " + val + str + opt);
        res = opt + 1;
    }

    static void PrintValueShort() => Console.WriteLine("Some value");


    static void Main()
    {
        int i = 0;
        PrintValue(val: 5, str: "string", out var x, 5);
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