using System.Text.Json;
using System.Text.RegularExpressions;

namespace beetroot_csharp_106;

public class Program
{
    public static void Main(string[] args)
    {
        // string input = "The quick brown fox jumps over the lazy dog.";
        // string pattern = "fox";
        // Match match = Regex.Match(input, pattern);
        // if (match.Success)
        // {
        //     Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
        // }
        // else Console.WriteLine("Not found");
        // string input = "The quick brown fox jumps over the lazy dog.";
        // string pattern = @"\b\w{4}\b";
        // MatchCollection matches = Regex.Matches(input, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
        // }
        // string input = "The quick brown fox jumps over the lazy dog.";
        // string pattern = @"\b\w{4}\b";
        // string replacement = "someword";
        // string result = Regex.Replace(input, pattern, replacement);
        // Console.WriteLine(result);
        // string input = "+38(050)12345";
        // string input1 = "+38(050)1234567";
        // string input2 = "+38(050)1234";
        // string pattern = @"\+38\(0\d{2}\)\d{5,7}"; // +38(0xx)xxxxxxx
        // // string pattern = @"\b\w{4}\b";
        // bool isMatch = Regex.IsMatch(input, pattern);
        // bool isMatch1 = Regex.IsMatch(input1, pattern);
        // bool isMatch2 = Regex.IsMatch(input2, pattern);
        // Console.WriteLine(isMatch);
        // string i1 = "Іваненко І.І.";
        // string i2 = "Iваненко Іван Іванович";
        // int firstI = (int) i1[0];
        // int secI = (int) i2[0];
        // string pattern1 = @"^[А-ЩЬЮЯҐЄІЇ][а-щьюяґєії']+\s[А-ЩЬЮЯҐЄІЇ]\.[А-ЩЬЮЯҐЄІЇ]\.$"; // ^ - start of the string
        // Regex regex = new Regex(pattern1);
        // bool isMatch3 = regex.IsMatch(i1);
        // bool isMatch4 = regex.IsMatch(i2);

//         string email = "example@gmail.com";
//         // var simplePattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
//         string pattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
//         Regex regex = new Regex(pattern);
//         bool isMatch = regex.IsMatch(email);
//         Console.WriteLine(isMatch); // виведе "True”
//
// Console.WriteLine();

        // string filePath = "C:/example.txt";
        // string p2 = "../../../1/Text.txt";
        // if (File.Exists(p2))
        // {
        //     Console.WriteLine("The file exists.");
        // }
        // else
        // {
        //     Console.WriteLine("The file does not exist.");
        // }
        int a = 0;
        try
        {
            a = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        string filePath = "Text1.txt";
        string[] lines = {"First line",
            "\r\n",
            "Second line",
            Environment.NewLine,
            "Third line"};
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
        using (var fileStream =
               new FileStream("Person.json",
                   FileMode.OpenOrCreate))
        {
            return JsonSerializer // returns Person[]
                .Deserialize<Person[]>(fileStream);
        }
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