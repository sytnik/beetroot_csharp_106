using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http.Json;
using System.Text;
using System.Xml.Serialization;
using CsvHelper;
using LmsClassLibrary.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SysTextJson = System.Text.Json.JsonSerializer;

namespace ConsoleApp;

public class Program
{
    public static ServiceProvider ConfigureServices()
    {
        var collection = new ServiceCollection();
        collection.AddDbContext<TestAppContext>
            (builder => builder.UseInMemoryDatabase("TestDb"));
        return collection.BuildServiceProvider();
    }

    public static async Task Main()
    {
        // init data
        var provider = ConfigureServices();
        var context = provider.GetService<TestAppContext>();
        var dto = InitData(100);
        // save faculties
        var faculties1 = dto.Faculties;
        await context.Faculties.AddRangeAsync(faculties1);
        // and departments
        var departments1 = faculties1
            .SelectMany(faculty => faculty.Departments)
            .Distinct()
            .ToList();
        // await context.Departments.AddRangeAsync(departments1);
        await context.SaveChangesAsync();
        // retrieve faculties
        var faculties3 = await context.Faculties.ToListAsync();
        var departments3 = await context.Departments.ToListAsync();
        await PrintCatFacts();
        await GetResource("https://jsonplaceholder.typicode.com/posts/1");
        await SomeMethod();
        // List<int> numbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
        Console.OutputEncoding = Encoding.UTF8;
        List<int> numbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        // Створення безпечної для потоків колекції для зберігання квадратів чисел
        ConcurrentBag<int> squares = new ConcurrentBag<int>();

        // Виконання паралельних операцій на кожному елементі колекції numbers
        Parallel.ForEach(numbers, number =>
        {
            Console.WriteLine($"Обробка числа {number} на потоці {Task.CurrentId}");
            int square = number * number;
            squares.Add(square);
        });
        Console.WriteLine("Квадрати чисел:");
        foreach (int square in squares.OrderBy(num => num))
        {
            Console.WriteLine(square);
        }

        List<int> numbers1 = new List<int> {23, 12, 45, 67, 89, 30, 5, 14};
        var evenNumbers = numbers1.AsParallel().Where(n => n % 2 == 0).ToList();
        var faculties = InitData(100);
        var departments = faculties.FacultiesWithIdMoreThan(50);
        ToJsonSystemText(faculties, "structureDto1.json");
        var faculties2 = FromJsonSystemText<StructureDto>("structureDto1.json");
        var allDepartments = faculties2.FacultiesWithIdMoreThan(0)
            .SelectMany(idNameDto => idNameDto.Departments).ToArray();
        WriteToCsv("departments.csv", allDepartments);
        var departments2 = GetFromCsv("departments.csv");
        var stopwatch = Stopwatch.StartNew();
        var groups = ExcelTask.ParseGroups();
        stopwatch.Stop();
        var st1 = $"Elapsed time 1: {stopwatch.Elapsed.Milliseconds}";
        stopwatch.Restart();
        var groups2 = ExcelTask.ParseGroupsParallel();
        stopwatch.Stop();
        var st2 = $"Elapsed time 2: {stopwatch.Elapsed.Milliseconds}";
    }

    public static async Task<CatFactDTO[]> PrintCatFacts()
    {
        try
        {
            // long way
            var client = new HttpClient();
            var response = await client.GetAsync("https://cat-fact.herokuapp.com/facts");
            var content = await response.Content.ReadAsStringAsync();
            var catFacts = JsonConvert.DeserializeObject<CatFactsModel[]>(content);
            // short way
            var catFacts2 = await SysTextJson.DeserializeAsync<CatFactsModel[]>
                (await new HttpClient().GetStreamAsync("https://cat-fact.herokuapp.com/facts"));
            // even shorter way
            var catFacts3 = await new HttpClient()
                .GetFromJsonAsync<CatFactsModel[]>("https://cat-fact.herokuapp.com/facts");
            var dtos = catFacts3
                .Select(fact =>
                    new CatFactDTO(DateOnly.FromDateTime(fact.createdAt),
                        fact.text)).ToArray();
            foreach (var dto in dtos)
            {
                Console.WriteLine(dto);
            }

            return dtos;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return Array.Empty<CatFactDTO>();
        }
    }


    public static async Task<string> GetResource(string url)
    {
        // Створюємо екземпляр HttpClient
        using var httpClient = new HttpClient();
        // Визначаємо URL веб-сервісу
        try
        {
            // Надсилаємо GET-запит до веб-сервісу
            HttpResponseMessage response = await httpClient.GetAsync(url);
            // Переконуємося, що запит успішний
            response.EnsureSuccessStatusCode();
            // Отримуємо вміст відповіді як рядок
            string content = await response.Content.ReadAsStringAsync();
            // Виводимо вміст відповіді
            Console.WriteLine(content);
            return content;
        }
        catch (HttpRequestException exception)
        {
            var error = $"Error: {exception.Message}";
            Console.WriteLine(error);
            return error;
        }
    }

    static async Task SomeMethod()
    {
        using (var cts = new CancellationTokenSource())
        {
            // Запускаємо довготривалу операцію
            var longRunningTask = LongRunningOperationAsync(cts.Token);

            // Чекаємо 2 секунди
            await Task.Delay(2000);

            // Скасовуємо операцію
            cts.Cancel();

            try
            {
                await longRunningTask;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation was canceled.");
            }
        }
    }

    static async Task LongRunningOperationAsync(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            // Перевіряємо, чи операцію було скасовано
            cancellationToken.ThrowIfCancellationRequested();
            Console.WriteLine($"Iteration {i + 1}");
            await Task.Delay(1000);
        }
    }

    public static void ToXml<T>(T data, string fileName)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var writer = new StreamWriter(fileName);
        serializer.Serialize(writer, data);
    }

    public static T FromXml<T>(string fileName)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StreamReader(fileName);
        return (T) serializer.Deserialize(reader);
    }

    public static void ToJsonNewtonsoft<T>(T data, string fileName) =>
        File.WriteAllText(fileName, JsonConvert.SerializeObject(data));

    public static T FromJsonNewtonsoft<T>(string fileName) =>
        JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));

    public static void ToJsonSystemText<T>(T data, string fileName) =>
        File.WriteAllText(fileName, SysTextJson.Serialize(data));

    public static T FromJsonSystemText<T>(string fileName) =>
        SysTextJson.Deserialize<T>(File.ReadAllText(fileName));

    public static async Task ToJsonAsyncSystemText<T>(T data, string fileName) =>
        await File.WriteAllTextAsync(fileName, SysTextJson.Serialize(data));

    public static async Task<T> FromJsonAsyncSystemText<T>(string fileName) =>
        SysTextJson.Deserialize<T>(await File.ReadAllTextAsync(fileName));

    public static void WriteToCsv(string filename, IEnumerable<DepartmentIdNameSlugDto> departments)
    {
        using var writer = new StreamWriter(filename);
        using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csvWriter.WriteRecords(departments);
    }

    public static DepartmentIdNameSlugDto[] GetFromCsv(string filename)
    {
        using var reader = new StreamReader(filename);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csvReader.GetRecords<DepartmentIdNameSlugDto>().ToArray();
    }
}