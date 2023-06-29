namespace Lesson5;

enum Categories
{
    Electronics = 1,
    Food = 5,
    Automotive = 6,
    Arts = 10,
    BeautyCare = 11,
    Fashion = 15,
    WomanFashion = 15
}

class Program
{
    public static int[] ShrinkArray(int[] original, int newSize)
    {
        var newArray = new int[newSize];
        Array.Copy(original, original.Length - newSize, newArray, 0, newSize);
        return newArray;
    }

    static void Main()
    {
        // get element by emum
        var fashion = Categories.Fashion;
        var womanFashion = (int) Categories.WomanFashion;
        // by int
        var elem = 15;
        var enumVal = (Categories) Enum.Parse(typeof(Categories), elem.ToString());
// init array
        var strings = new string[5];
        var elems = new int[5];
        // int[] elems2 = {1, 2, 3, 4, 5};
        var elems0 = new[] {1, 2, 3, 4, 5};

        for (var i = 0; i < elems0.Length - 1; i++)
            elems0[i] += 1;
        foreach (var el in elems0)
            Console.WriteLine(el);
        var person =
            new Tuple<int, string, string>(1, "Steve", "Jobs");
        person = Tuple.Create(2, person.Item2, person.Item3);
        var person1 = Tuple.Create(1, "Steve", "Jobs");
        PrintTuple(person1);
        var persons = new[] {person, person1};
        var person2 = (Id: 1, FirstName: "Bill", LastName: "Gates");
        person2.Id = 3;
        PrintValueTuple(person2);

        void PrintTuple(Tuple<int, string, string> tuple) =>
            Console.WriteLine(tuple.Item1 + " " + tuple.Item2);

        void PrintValueTuple((int Id, string Name, string) tuple) =>
            Console.WriteLine(tuple.Id + " " + tuple.Name);

        string qwerty = "qwerty";
        var q = qwerty[1];
        char[] qwertyArrayGeneric = qwerty.ToArray();
        char[] qwertyArray = qwerty.ToCharArray();
        
        ShrinkArray(elems0, 2);
        var third = elems0[2];
        var last = elems0[elems0.Length - 1];
        var rangeFirst = elems0[0..0];
        var first = elems0[0];
        var sec = elems0[1];
        var last1 = elems0[^1];
        var secToLast = elems0[^2];
        elems0[4] = 10;
        Array.Resize(ref elems0, 8);
        elems0[5] = 15;
        Array.Resize(ref elems0, 4);

        int[] source = {5, 8, 6, 7, 3, 35, 4};
        var sorted1 = Sort(SortAlgorithmType.Selection, OrderBy.Asc, source);
        // SampleArray();
        MultidimensionalArray();
        JaggedArray();
        TupleTest();
        // LINQ
        // [] - array of some type
        var chArr = new[] {'a', 's', 'd'};

        var str = string.Join(',', source);
        var str1 = string.Join(",*, ", source);
        var str2 = string.Join("", chArr);

        Console.WriteLine(string.Join(", ", sorted1));
        var sorted2 = Sort(SortAlgorithmType.Bubble, OrderBy.Desc, source);
        Console.WriteLine(string.Join(", ", sorted2));
        var sorted3 = Sort(SortAlgorithmType.Insertion, OrderBy.Asc, 5, 8, 6, 7, 3, 35, 4);
        var sorted4 = Sort(SortAlgorithmType.Insertion, OrderBy.Asc, new[] {5, 8, 6, 7, 3, 35, 4});
        Console.WriteLine(string.Join(", ", sorted3));
        var t = TwoBeforeLastByRange(1, 2, 3, 4, 5);
        var a = Sort3d();
    }

    static int[,,] Sort3d()
    {
        // sample 3x4x5 array
        var myArray = new int[3, 4, 5]
        {
            {{6, 5, 4, 3, 2}, {1, 2, 3, 4, 5}, {6, 5, 4, 3, 2}, {1, 2, 3, 4, 5}},
            {{9, 8, 7, 6, 5}, {4, 5, 6, 7, 8}, {9, 8, 7, 6, 5}, {4, 5, 6, 7, 8}},
            {{3, 2, 1, 0, 9}, {8, 7, 6, 5, 4}, {3, 2, 1, 0, 9}, {8, 7, 6, 5, 4}}
        };
        // create an one-dimensional temp array
        var flatArray = new int[myArray.Length];
        // transfer the 3d array to 1d
        Buffer.BlockCopy(myArray, 0, flatArray,
            0, sizeof(int) * myArray.Length);
        // sort 1d array
        Array.Sort(flatArray);
        // transfer the sorted 1d array back to the 3d one
        Buffer.BlockCopy(flatArray, 0, myArray,
            0, sizeof(int) * myArray.Length);
        return myArray;
    }


    static int[] TwoBeforeLastByRange(params int[] array)
    {
        // from array[3] from last to array[1] from last
        return array[^3..^1];
    }

    // gereral Sort method
    static int[] Sort(SortAlgorithmType type, OrderBy order, params int[] source)
    {
        switch (type)
        {
            case SortAlgorithmType.Selection:
                return SelectionSort(order, source);
            case SortAlgorithmType.Bubble:
                return BubbleSort(order, source);
            case SortAlgorithmType.Insertion:
                return InsertionSort(order, source);
            default:
                return source;
        }
    }

    // SelectionSort
    static int[] SelectionSort(OrderBy order, params int[] source)
    {
        var n = source.Length;
        for (var i = 0; i < n - 1; i++)
        {
            var minIndex = i;
            for (var j = i + 1; j < n; j++)
            {
                if (order == OrderBy.Asc && source[j] < source[minIndex])
                {
                    minIndex = j;
                }
                else if (order == OrderBy.Desc && source[j] > source[minIndex])
                {
                    minIndex = j;
                }
            }

            var temp = source[minIndex];
            source[minIndex] = source[i];
            source[i] = temp;
            
            // (source[minIndex], source[i]) = (source[i], source[minIndex]);
        }

        return source;
    }

    // BubbleSort
    static int[] BubbleSort(OrderBy order, params int[] source)
    {
        var n = source.Length;
        for (var i = 0; i < n - 1; i++)
        {
            for (var j = 0; j < n - i - 1; j++)
            {
                if (order == OrderBy.Asc && source[j] > source[j + 1])
                    (source[j], source[j + 1]) = (source[j + 1], source[j]);
                else if (order == OrderBy.Desc && source[j] < source[j + 1])
                {
                    (source[j], source[j + 1]) = (source[j + 1], source[j]);
                }
            }
        }

        return source;
    }

    // InsertionSort
    static int[] InsertionSort(OrderBy order, params int[] source)
    {
        var n = source.Length;
        for (var i = 1; i < n; i++)
        {
            var key = source[i];
            var j = i - 1;

            if (order == OrderBy.Asc)
            {
                while (j >= 0 && source[j] > key)
                {
                    source[j + 1] = source[j];
                    j--;
                }
            }
            else if (order == OrderBy.Desc)
            {
                while (j >= 0 && source[j] < key)
                {
                    source[j + 1] = source[j];
                    j--;
                }
            }

            source[j + 1] = key;
        }

        return source;
    }

    enum SortAlgorithmType
    {
        Selection,
        Bubble,
        Insertion
    }

    enum OrderBy
    {
        Asc,
        Desc
    }

    static void SampleArray()
    {
        //init array
        var arr = new int[0];
        arr = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
        // index
        var element = arr[5];
        // Index
        var index = new Index(1);
        var second = arr[index];
        //Range
        var twoElements = arr[0..2];
        var twoLast = arr[^1..^0];
        var two = arr[^2..];
        var two1 = arr[^2..];
        var two2 = arr[^3..2];
        // first elem as new array
        var range1 = new Range(0, 1);
        var firstButArr = arr[range1];
        // take four first
        var range2 = new Range(new Index(0), 5);
        var firstFour = arr[range2];
    }

    static void MultidimensionalArray()
    {
        // 2-dimensional - table
        // 0.0 0.1
        // 1.0 1.1
        // 2.0 2.1
        // 0 0
        var arr = new int[4, 2];
        //3-dimensional - cube
        var array1 = new int[4, 2, 3];
        // Two-dimensional array.
        var array2D = new int[,] {{1, 2}, {3, 4}, {5, 6}, {7, 8}};
        // The same array with dimensions specified.
        var array2Da = new int[4, 2] {{1, 2}, {3, 4}, {5, 6}, {7, 8}};
    }

    static void JaggedArray()
    {
        // 0 0 0 0 0
        // 0 0 0 0
        // 0 0     
        // jagged array with 3 different rows
        var jaggedArray = new int[3][];
        jaggedArray[0] = new int[5];
        jaggedArray[1] = new int[4];
        jaggedArray[2] = new int[2];
        // init array
        int[][] jaggedArray2 = new int[][]
        {
            new int[] {1, 3, 5, 7, 9},
            new int[] {0, 2, 4, 6},
            new int[] {11, 22} // 2
        };
        var secondRow = jaggedArray2[1];
        var val = jaggedArray2[2][1];

        var oneElement = 100;
        var oneElementArray = new[] {100};
        var value = oneElementArray[0]; // 100
    }

    static void TupleTest()
    {
        // tuple (not the valuetuple !) - кортеж
        // with type
        var person = new Tuple<int, string, string>(1, "Steve", "Jobs");

        // create from arguments
        var person1 = Tuple.Create(1, "Steve", "Jobs");
        var x = person1.Item1; // returns 1
        var y = person1.Item2; // returns "Steve"
        var z = person1.Item3; // returns "Jobs"
        // person1.Item1 = 3;

        // valuetuple - кортеж значень (.net fw 4.7+ or System.ValueTuple)
        // long notation
        ValueTuple<int, string, string> person4 = (1, "Bill", "Gates");
        var q = person4.Item1; // returns 1
        var w = person4.Item2; // returns "Bill"
        var e = person4.Item3; // returns "Gates"

        // new notation
        var person2 = (1, "Bill", "Gates");
        //equivalent Tuple
        var person3 = Tuple.Create(1, "Bill", "Gates");

        // big valuetuple
        var numbers = (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);

        // named tuple
        (int Id, string FirstName, string LastName) person5 = (1, "Bill", "Gates");
        var a = person5.Id; // returns 1
        var s = person5.FirstName; // returns "Bill"
        var d = person5.LastName; // returns "Gates"
        person5.FirstName = "other";

        // var tuple
        // var - compile type!
        // simple init
        var sometuple = (1, "someText", Guid.NewGuid(), 1.34);
        // var text = sometuple[1]; // no index
        var text = sometuple.Item2;
        // named tuple initialization
        // GUID (globally unique identifier)
        var someDouble = 1.34;
        (int id, string textField, Guid someGuid, double doubleVal) tuple2 =
            (1, "someText", Guid.NewGuid(), someDouble);
        var val1 = tuple2.someGuid;

        // named tuple (userId, firstName, isActive)
        // [] of tuples
        (int userId, string firstName, bool isActive)[] users =
            new (int userId, string firstName, bool isActive)[]
            {
                (1, "John", true),
                (2, "Jane", true),
                (3, "Hanz", false)
            };
        var secondName = users[1].firstName; //Jane
        var thirdUserIsActive = users[2].isActive; //false
    }
}