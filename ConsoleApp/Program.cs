using System.Collections;
using System.Drawing;
using LmsClassLibrary.Model;

namespace ConsoleApp;

public class Program
{
    public static void Print(IEnumerable<int> someData)
        => Console.WriteLine(string.Join("***", someData));

    public static void Main(string[] args)
    {
        var coll = new MyCollection();
        // coll.data[0] = 1;
        coll[0] = 1;
        var val1 = coll[1];
        ArrayList list1 = new ArrayList {1, 2, 3, "str", null};
        var elem3 = (int) list1[2];
        List<object> list2 = new List<object> {1, 2, 3, "str", null};
        List<int> strlist2 = new List<int> {1, 2, 3};
        var elem4 = strlist2[2];
        var str = new TestStruct();
        var p = new Point(1, 1);
        var p2 = new Point(1, 1);
        var mp = new MyPoint(1, 1, "1");
        var mp2 = new MyPoint(1, 1, "1");
        var p3 = mp + mp2;
        var dt = DateTime.Now;
        var str2 = str;
        object o = str2;
        int.TryParse(o.ToString(), out var i3);
        int i = o is int ? (int) o : -1;
        int i2 = o is int i1 ? i1 : -1;
        Console.WriteLine(str2);
        Console.WriteLine(str2.ToString());
        Console.WriteLine($"{str2}");
        var testclass1 = new TestClass {Id = 1, Name = "test1"};
        var testclass2 = new TestClass {Id = 1, Name = "test1"};
        var testclass3 = testclass2;
        testclass1.Equals(null);
        testclass1.Equals(testclass2);
        testclass2.Equals(testclass3);
        var data = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        var data1 = data.ToList();
        var data2 = data.ToHashSet();
        Print(data);
        Print(data1);
        Print(data2);
        var submission = new Submission(7, "new submission");
        var s1 = submission.DisplayContent();
        var entityIdName = new EntityWithIdAndName(5, "somename");
        var course = new Course();
        Console.WriteLine(course.ToString());
        var course2 = new Course();
        var course3 = course2;
        var eq = course == course2;
        var eq2 = course3.Equals(course2);
        var eq3 = course.CourseEquals(course2);
        var courseRecord = new CourseRecord();
        Console.WriteLine(courseRecord.ToString());
        courseRecord.Id = 5;
        var courseRecord2 = new ShortCourseRecord();
        var courseRecord3 = new ShortCourseRecord();
        var recordEq = courseRecord2 == courseRecord3;
        var recordEq2 = courseRecord2.Equals(courseRecord3);
        Console.WriteLine(courseRecord2.ToString());
        courseRecord2 = courseRecord2 with {Id = 5, Name = "Some Name"};
        Console.WriteLine(courseRecord2.ToString());
        var singleton = Singleton.Instance;
        singleton.Id = 2;
        var singleton2 = Singleton.Instance;
        // using var fileStream = new FileStream("Person.json",
        //     FileMode.OpenOrCreate);
        var user = new User("Ivan", "Ivanov");
        // user.SystemGuid = Guid.NewGuid();
        var stringId = user.SystemGuid.ToString();
        var user2 = new User(1, "user2", "user2", "user2", "user2");
        // user2.Id = 2;
        Console.WriteLine(user.GetFullName());
        Console.WriteLine(
            User.GetFullNameStatic(user.FirstName, user.LastName));
        GC.Collect();
        Guid guid1 = Guid.Empty;
        Guid guid = Guid.NewGuid();
        string s = null;
        var char1 = s?.ElementAtOrDefault(100);
        int[] arr = null;
        // if arr is null
        // if index is out of range
        // results in 0
        var val = arr?.ElementAtOrDefault(3) ?? 0;
        short a = 0;
        try
        {
            s = Console.ReadLine();
            if (s.Any(ch => !char.IsDigit(ch)))
                throw new FormatException("Some exception");
            short.TryParse(s, out a);
            a = Convert.ToInt16(s);
        }

        catch (FormatException exception)
        {
            Console.WriteLine($"The input string is not a sequence of digits. {s}");
        }
        catch (OverflowException exception)
        {
            Console.WriteLine($"The number cannot fit in an Int16. {s}");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"The input string is null. {s}");
        }
        finally
        {
            s = null;
        }

        string filePath = "Text1.txt";
        string[] lines =
        {
            "First line",
            "\r\n",
            "Second line",
            Environment.NewLine,
            "Third line"
        };
        File.WriteAllLines(filePath, lines);
        string fileContents = "This is an example text.";
        File.AppendAllText(filePath, fileContents);
        //
        // string[] lines1 = File.ReadAllLines(filePath);
        // File.Delete(filePath);
        // File.Delete("Text12.txt");
        // WorkWithFile();
        var persons = new[]
        {
            new Person("user1", 25),
            new Person("user2", 30),
            new Person("user3", 35)
        };
        Serialize(persons);
        var personsFromFile = Deserialize();
        Console.WriteLine();
    }

    static void Serialize(Person[] persons)
    {
        using (var fileStream =
               new FileStream("Person.json",
                   FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fileStream, persons);
        }
    }

    public static Person[] Deserialize()
    {
        using var fileStream = new FileStream("Person.json",
            FileMode.OpenOrCreate);
        return JsonSerializer // returns Person[]
            .Deserialize<Person[]>(fileStream);
    }

    private static void WorkWithFile()
    {
        var users = File.ReadAllLines("Text.txt");
        var newUser = "User3 0971236547";
        File.AppendAllText("Text.txt",
            Environment.NewLine);
        File.AppendAllText("Text.txt", newUser);
        var newUserArr = new[] {newUser};
        File.AppendAllText("Text.txt", "\r\n");
        File.AppendAllLines("Text.txt", newUserArr);
        var filePath = "Text1.txt";
        File.Delete(filePath);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Console.WriteLine("The file has been deleted.");
        }
        else
        {
            Console.WriteLine("The file does not exist.");
        }
    }

    // клас Person (public = доступ без обмежень)
    public class Person
    {
        // поле (field) класу
        public string Name { get; set; }

        // властивість (property) класу
        public int Age { get; set; }

        // конструктор (constructor) класу
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // метод (method) класу
        public void PrintInfo() => Console.WriteLine($"Name: {Name}, Age: {Age}");
    }

    public static void RegexTest()
    {
        var input = "The quick brown fox jumps over the lazy dog.";
        var pattern = "fox";
        var match = Regex.Match(input, pattern);
        if (match.Success)
        {
            Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
        }

        input = "The quick brown fox jumps over the lazy dog.";
        pattern = @"\b\w{4}\b"; // word with 4 letters
        var matches = Regex.Matches(input, pattern);
        foreach (Match match1 in matches)
        {
            Console.WriteLine($"Found '{match1.Value}' at position {match1.Index}");
        }

        input = "The quick brown fox jumps over the lazy dog.";
        pattern = @"\s";
        var replacement = "_";
        var result = Regex.Replace(input, pattern, replacement);
        Console.WriteLine(result);

        input = "The quick brown fox jumps over the lazy dog.";
        pattern = "fox";
        var isMatch = Regex.IsMatch(input, pattern);
        Console.WriteLine(isMatch);

        pattern = @"\+38\(0\d{2}\)\d{7}"; // +38(0xx)xxxxxxx
        input = "+38(099)1234567";
        var regex = new Regex(pattern);
        isMatch = regex.IsMatch(input); // true

        pattern = @"^[А-ЩЬЮЯҐЄІЇ][а-щьюяґєії']+\s[А-ЩЬЮЯҐЄІЇ]\.[А-ЩЬЮЯҐЄІЇ]\.$"; // ^ - start of the string
        regex = new Regex(pattern);

        input = "Іванов І.П.";
        isMatch = regex.IsMatch(input); // true

        var email = "example@example.com";
        pattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
        regex = new Regex(pattern);

        isMatch = regex.IsMatch(email);
        Console.WriteLine(isMatch); // виведе "True”
    }
}